namespace Garage3.Data.Entities
{
    public class VehicleTypeRate : Entity
    {
        public virtual Membership Membership { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual decimal Fee { get; set; }
    }
}