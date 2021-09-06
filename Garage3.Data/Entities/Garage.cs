using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Garage3.Data
{
    public class Garage : Entity
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal HourlyRate { get; set; }
    }
}
