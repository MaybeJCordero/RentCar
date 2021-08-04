using System;
using System.Collections.Generic;
using System.Text;

namespace CarCore.Entities
{
    public class Car
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool Rent { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
    }
}
