namespace Garage3.Data.Entities
{
    public class MembershipType
    {
        public virtual MembershipType Basic { get; set; }
        public virtual MembershipType PRO { get; set; }
    }
}