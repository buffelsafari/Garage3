using System;

namespace Garage3.Data.Entities
{
    public class VehicleType : Entity
    {
        public virtual int AmountPlaces { get; set; }
        public virtual decimal BasicFee { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }
    }

    public enum VehicleCategory
    {
        CAR = 0,
        MOTORCYCLE = 1,
        AIRPLANE = 2,
        TRUCK = 3
    }
}