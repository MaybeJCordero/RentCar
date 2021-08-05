using CarCore.Entities;
using CarCore.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Queues
{
    public class CarConsumer : IConsumer<Car>
    {
        private readonly ICarRepository _carRepository;

        public CarConsumer(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Consume(ConsumeContext<Car> context)
        {
            //Update cliets's name
        }
    }
}
