    using CarCore.Entities;
using CarCore.Interfaces;
using ClientCore.Entities;
using ClientCore.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Queues
{
    public class ClientConsumer : IConsumer<Client>
    {
        private readonly ICarRepository _repository;
        public ClientConsumer(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<Client> context)
        {
            await _repository.UpdateByClient(context.Message.ID, context.Message.Name);
        }
    }
}
