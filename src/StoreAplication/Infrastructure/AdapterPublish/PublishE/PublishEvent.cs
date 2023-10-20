using Domain.Entities;
using RabbitMQ.Client;
using System.Text;
using UseCasesCommand.Gateway.Repositories;

namespace AdapterPublish.PublishE
{
    public class PublishEvent : IPublishEventRepository
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public PublishEvent()
        {
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
            _channel.QueueBind("queue.product.purchase", "topic_exchange", "topic.routing.product.purshase");
            _channel.QueueBind("queue.product.customer-sale", "topic_exchange", "topic.routing.product.customer-sale");
            _channel.QueueBind("queue.product.reseller-sale", "topic_exchange", "topic.routing.product.reseller-sale");
            _channel.QueueBind("queue.user.register", "topic_exchange", "topic.routing.user");

            _channel.QueueDeclare("queue.branch.register.socket", true, false, false);
            _channel.QueueDeclare("queue.product.register.socket", true, false, false);
            _channel.QueueDeclare("queue.product.purchase.socket", true, false, false);
            _channel.QueueDeclare("queue.product.customer-sale.socket", true, false, false);
            _channel.QueueDeclare("queue.product.reseller-sale.socket", true, false, false);
            _channel.QueueDeclare("queue.user.register.socket", true, false, false);
            _channel.QueueBind("queue.branch.register.socket", "topic_exchange", "topic.routing.branch.socket");
            _channel.QueueBind("queue.product.register.socket", "topic_exchange", "topic.routing.product.socket");
            _channel.QueueBind("queue.product.purchase.socket", "topic_exchange", "topic.routing.product.purshase.socket");
            _channel.QueueBind("queue.product.customer-sale.socket", "topic_exchange", "topic.routing.product.customer-sale.socket");
            _channel.QueueBind("queue.product.reseller-sale.socket", "topic_exchange", "topic.routing.product.reseller-sale.socket");
            _channel.QueueBind("queue.user.register.socket", "topic_exchange", "topic.routing.user.socket");

        }

        public void PublishRegisterBranchEvent(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "topic.routing.branch", null, body);
            _channel.BasicPublish("topic_exchange", "topic.routing.branch.socket", null, body);
            Console.WriteLine($"Enviado: '{eventToPublished.EventBody}'");
        }

        public void PublishRegisterProduct(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "topic.routing.product", null, body);
            _channel.BasicPublish("topic_exchange", "topic.routing.product.socket", null, body);
            Console.WriteLine($"Enviado: '{eventToPublished.EventBody}'");
        }

        public void PublishRegisterProductInvetoryStock(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "topic.routing.product.purchase", null, body);
            Console.WriteLine($"Enviado: '{eventToPublished.EventBody}'");
        }

        public void PublishRegisterProductSaleCustomer(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "topic.routing.product.customer-sale", null, body);
            Console.WriteLine($"Enviado: '{eventToPublished.EventBody}'");
        }

        public void PublishRegisterProductSaleReseller(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "topic.routing.product.reseller-sale", null, body);
            Console.WriteLine($"Enviado: '{eventToPublished.EventBody}'");
        }
        public void PublishRegisterUser(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "topic.routing.user", null, body);
            Console.WriteLine($"Enviado: '{eventToPublished.EventBody}'");
        }
    }

}

