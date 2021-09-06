namespace Garage3.Data.Entities
{
    public class ParkingStatus : Entity
    {
        public virtual ParkEvent ParkEvent { get; set; }
        public virtual bool IsParked { get; set; }
        public virtual ParkingLot ParkingLot { get; set; }
    }
}