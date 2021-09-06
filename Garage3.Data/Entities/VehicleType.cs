namespace Garage3.Data.Entities
{
    public class VehicleType : Entity
    {
        public virtual int AmountPlaces { get; set; }
        public virtual decimal BasicFee { get; set; }
    }
}