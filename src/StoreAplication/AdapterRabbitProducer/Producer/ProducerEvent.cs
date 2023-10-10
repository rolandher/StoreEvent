using Domain.Entities;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Gateway.Repositories;

namespace AdapterRabbitProducer.Producer
{
    public class ProducerEvent : IPublishEventRepository
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public ProducerEvent()
        {
            var factory = new ConnectionFactory() 
            
            {
                HostName = "localhost", 
                Port = 5672,
                UserName = "guest",
                Password = "guest",
            
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("topic_exchange", ExchangeType.Topic, true);
            _channel.QueueDeclare("queue.branch.register", true, false, false);
            _channel.QueueDeclare("queue.user.register", true, false, false);
            _channel.QueueDeclare("queue.product.register", true, false, false);
            _channel.QueueDeclare("queue.product.purchase", true, false, false);
            _channel.QueueDeclare("queue.product.customer-sale", true, false, false);
            _channel.QueueDeclare("queue.product.reseller-sale", true, false, false);
            _channel.QueueBind("queue.branch.register", "topic_exchange", "topic.routing.branch");
            _channel.QueueBind("queue.user.register", "topic_exchange", "topic.routing.user");
            _channel.QueueBind("queue.product.register", "topic_exchange", "topic.routing.product");
            _channel.QueueBind("queue.product.purchase", "topic_exchange", "topic.routing.product");
            _channel.QueueBind("queue.product.customer-sale", "topic_exchange", "topic.routing.product");
            _channel.QueueBind("queue.product.reseller-sale", "topic_exchange", "topic.routing.product");
        }

        public void PublishRegisterBranchEvent(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "branch.register", null, body);
        }

        public void PublishRegisterUser(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "user.register", null, body);
        }

        public void PublishRegisterProduct(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "product.register", null, body);
        }

        public void PublishRegisterProductInvetoryStock(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "product.purchase", null, body);
        }

        public void PublishRegisterProductSaleCustomer(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "product.customer-sale", null, body);
        }

        public void PublishRegisterProductSaleReseller(StoredEventEntity eventToPublished)
        {
            var body = Encoding.UTF8.GetBytes(eventToPublished.EventBody);
            _channel.BasicPublish("topic_exchange", "product.reseller-sale", null, body);
        }
    }

}

   