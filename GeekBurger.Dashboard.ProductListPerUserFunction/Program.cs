using Microsoft.Azure.ServiceBus;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.ProductListPerUserFunction
{
    class Program
    {
        const string ServiceBusConnectionString = "{ServiceBus connection string}";
        const string QueueName = "productlistperuser";
        static IQueueClient queueClient;

        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName, ReceiveMode.PeekLock);

            Console.WriteLine("Pressione CTRL+C para interromper o recebimento das mensagens.");

            RegistrarNaFila();
            Console.ReadKey();

            await queueClient.CloseAsync();
        }

        static void RegistrarNaFila()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            queueClient.RegisterMessageHandler(LerFila, messageHandlerOptions);
        }

        static async Task LerFila(Message message, CancellationToken token)
        {
            MenuPerUserModel entidade = JsonConvert.DeserializeObject<MenuPerUserModel>(Encoding.UTF8.GetString(message.Body));

            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=menuperuserdashboard;AccountKey=qi8LIkld3cZT7z3a1qm8NaveU12GVLI0m77T3VmvcYhPKJ3ArzFrNTVEFexWvbD7B5+Py6MdGQdRW2FbmxFdLg==;EndpointSuffix=core.windows.net");

            CloudTableClient tableClient = account.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("menuperuserdashboard");
            bool created = await table.CreateIfNotExistsAsync();

            var retry = false;
            do
            {
                TableOperation operation = TableOperation.Insert(new MenuPerUserModel("menuperuserdashboard", entidade.UserId) { UserId = entidade.UserId, ProductCount = entidade.ProductCount, Restrictions = entidade.Restrictions });

                TableResult insertResult = new TableResult();
                try
                {
                    insertResult = await table.ExecuteAsync(operation);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    throw exc;
                }

                if (insertResult.HttpStatusCode == 503 || insertResult.HttpStatusCode == 504 || insertResult.HttpStatusCode == 408)
                    retry = true;

            } while (retry == true);

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Erro ao ler fila: {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Detalhes:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}
