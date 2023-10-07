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
                Port = 15672,
                UserName = "guest",
                Password = "guest",
            
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "event",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public void Publish(object eventToPublished)
        {
            throw new NotImplementedException();
        }
    }

}

   