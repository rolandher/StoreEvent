using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using UseCasesQuery.Factory;

namespace AdapterSubscribe.SubscribeE
{
    public class SubscribeEvent : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IBranchUseCaseQueryFactory _factorybranch;
        private readonly IProductUseCaseQueryFactory _factoryProduct;
        private readonly IUserUserCaseQueryFactory _factoryUser;

        public SubscribeEvent(IBranchUseCaseQueryFactory factoryBranch, IProductUseCaseQueryFactory factoryProduct,
            IUserUserCaseQueryFactory factoryUser)
        {
            _factorybranch = factoryBranch;
            _factoryProduct = factoryProduct;
            _factoryUser = factoryUser;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("topic_exchange", ExchangeType.Topic, true);
            _channel.QueueDeclare("queue.branch.register", true, false, false);
            _channel.QueueDeclare("queue.product.register", true, false, false);
            _channel.QueueDeclare("queue.product.purchase", true, false, false);
            _channel.QueueDeclare("queue.product.customer-sale", true, false, false);
            _channel.QueueDeclare("queue.product.reseller-sale", true, false, false);
            _channel.QueueDeclare("queue.user.register", true, false, false);
            _channel.QueueBind("queue.branch.register", "topic_exchange", "topic.routing.branch");
            _channel.QueueBind("queue.product.register", "topic_exchange", "topic.routing.product");
            _channel.QueueBind("queue.product.purchase", "topic_exchange", "topic.routing.product.purchase");
            _channel.QueueBind("queue.product.customer-sale", "topic_exchange", "topic.routing.product.customer-sale");
            _channel.QueueBind("queue.product.reseller-sale", "topic_exchange", "topic.routing.product.reseller-sale");
            _channel.QueueBind("queue.user.register", "topic_exchange", "topic.routing.user");


        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)

        {
            var registerBranchUseCase = _factorybranch.Create();
            var consumerTopic1 = new EventingBasicConsumer(_channel);
            consumerTopic1.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await registerBranchUseCase.RegisterBranch(message);
                Console.WriteLine($"Recibido en Topic 1: '{message}'");
            };

            var registerProductUseCase = _factoryProduct.Create();
            var consumerTopic2 = new EventingBasicConsumer(_channel);
            consumerTopic2.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await registerProductUseCase.RegisterProduct(message);
                Console.WriteLine($"Recibido en Topic 2: '{message}'");
            };

            var registerCustomerSaleProductUseCase = _factoryProduct.RegisterCustomerSale();
            var consumerTopic3 = new EventingBasicConsumer(_channel);
            consumerTopic3.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await registerCustomerSaleProductUseCase.RegisterProductFinalCustomerSale(message);
                Console.WriteLine($"Recibido en Topic 3: '{message}'");
            };

            var registerResellerSaleProductUseCase = _factoryProduct.RegisterResellerSale();
            var consumerTopic4 = new EventingBasicConsumer(_channel);
            consumerTopic4.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await registerResellerSaleProductUseCase.RegisterResellerSale(message);
                Console.WriteLine($"Recibido en Topic 4: '{message}'");
            };

            var registerProductStockUseCase = _factoryProduct.RegisterProductStock();
            var consumerTopic5 = new EventingBasicConsumer(_channel);
            consumerTopic5.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await registerProductStockUseCase.RegisterProductInventoryStock(message);
                Console.WriteLine($"Recibido en Topic 5: '{message}'");
            };

            var registerUserUseCase = _factoryUser.Create();
            var consumerTopic6 = new EventingBasicConsumer(_channel);
            consumerTopic6.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await registerUserUseCase.RegisterUserAsync(message);
                Console.WriteLine($"Recibido en Topic 6: '{message}'");
            };

            _channel.BasicConsume(queue: "queue.branch.register", autoAck: true, consumer: consumerTopic1);
            _channel.BasicConsume(queue: "queue.product.register", autoAck: true, consumer: consumerTopic2);
            _channel.BasicConsume(queue: "queue.product.purchase", autoAck: true, consumer: consumerTopic5);
            _channel.BasicConsume(queue: "queue.product.customer-sale", autoAck: true, consumer: consumerTopic3);
            _channel.BasicConsume(queue: "queue.product.reseller-sale", autoAck: true, consumer: consumerTopic4);
            _channel.BasicConsume(queue: "queue.user.register", autoAck: true, consumer: consumerTopic6);


            return Task.CompletedTask;

        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Close();
            _connection.Close();
            await base.StopAsync(cancellationToken);
        }
    }


}
