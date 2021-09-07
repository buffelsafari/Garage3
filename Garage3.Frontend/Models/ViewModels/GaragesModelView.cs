using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage3.Frontend.Models.ViewModels
{
    public class GaragesModelView
    {
        public int GarageId { get; set; }
        public string Name{ get;set;}
        public string Description { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
