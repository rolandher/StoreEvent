﻿using Domain.Entities;
using Domain.Factory;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesQuery.Factory;

namespace AdapteRabbitConsumer.Consumer
{
    public class ConsumerEvent : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IBranchUseCaseQueryFactory _factory;

        public ConsumerEvent(IBranchUseCaseQueryFactory factoryBranch)
        {
            _factory = factoryBranch;
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
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
        protected override Task ExecuteAsync(CancellationToken stoppingToken)

        {
            var registerBranchUseCase = _factory.Create();
            var consumerTopic1 = new EventingBasicConsumer(_channel);
            consumerTopic1.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await registerBranchUseCase.RegisterBranch(message);
                Console.WriteLine($"Recibido en Topic 1: '{message}'");
            };

            var consumerTopic2 = new EventingBasicConsumer(_channel);
            consumerTopic2.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recibido en Topic 2: '{message}'");
            };

            var consumerTopic3 = new EventingBasicConsumer(_channel);
            consumerTopic3.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recibido en Topic 3: '{message}'");
            };

            var consumerTopic4 = new EventingBasicConsumer(_channel);
            consumerTopic4.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recibido en Topic 4: '{message}'");
            };

            var consumerTopic5 = new EventingBasicConsumer(_channel);
            consumerTopic5.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recibido en Topic 5: '{message}'");
            };

            var consumerTopic6 = new EventingBasicConsumer(_channel);
            consumerTopic6.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recibido en Topic 6: '{message}'");
            };

            _channel.BasicConsume(queue: "queue.branch.register",
                                     autoAck: true,
                                     consumer: consumerTopic1);

            _channel.BasicConsume(queue: "queue.product.register",
                                     autoAck: true,
                                     consumer: consumerTopic2);

            _channel.BasicConsume(queue: "queue.product.customerSale",
                                     autoAck: true,
                                     consumer: consumerTopic3);

            _channel.BasicConsume(queue: "queue.product.resellerSale",
                                     autoAck: true,
                                     consumer: consumerTopic4);

            _channel.BasicConsume(queue: "queue.product.inventoryStock",
                                     autoAck: true,
                                     consumer: consumerTopic5);

            _channel.BasicConsume(queue: "queue.user.register",
                                     autoAck: true,
                                     consumer: consumerTopic6);

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
