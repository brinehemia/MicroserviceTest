using MassTransit;
using MicroserviceB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceB.Services
{
    public interface IRecieverMessageService
    {
        Task Consume(ConsumeContext<NotificationTest> test);
    }

    public class RecieverMessageService : IRecieverMessageService, IConsumer<NotificationTest>
    {
        // Request from message broker ( Rabbitmq )
        public async Task Consume(ConsumeContext<NotificationTest> test)
        {
            var GetAllMessage = test.Message;

            // Get NotificationTest ( NotifMessage )
            var GetNotifMessage = test.Message.NotifMessage;

            // ... Process Data ... 
        }

    }
}
