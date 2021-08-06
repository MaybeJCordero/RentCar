using CarCore.Entities;
using CarCore.Interfaces;
using ClientCore.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Queues
{
    public class CarConsumer : IConsumer<Car>
    {
        private readonly IClientRepository _repository;

        public CarConsumer(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<Car> context)
        {
            await _repository.UpdateByCar(context.Message.ClientID, context.Message.ClientName);
        }
    }
}
