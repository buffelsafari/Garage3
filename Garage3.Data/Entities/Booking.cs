using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Garage3.Data.Entities
{
    public class Booking : Entity
    {
        /// <summary>
        /// When the vehicle was checked in to the garage
        /// </summary>
        public virtual DateTime? CheckinTime { get; set; }

        /// <summary>
        /// When the vehicle was checked out of the garage
        /// </summary>
        public virtual DateTime? CheckoutTime { get; set; }

        /// <summary>
        /// Some redudancy for the nullable datetimes (to help making querying
        /// easier)
        /// </summary>
        public virtual bool CheckedIn { get; set; }

        /// <summary>
        /// Some redudancy for the nullable datetimes (to help making querying
        /// easier. Remember to set this as well when checking out the vehicle
        /// </summary>
        public virtual bool CheckedOut { get; set; }

        /// <summary>
        /// The vehicle this booking concerns
        /// </summary>
        public virtual Vehicle Vehicle { get; set; }

        /// <summary>
        /// The optional receipt. Only generated at checkout
        /// </summary>
        public virtual Receipt Receipt { get; set; }

        /// <summary>
        /// THe parkinglot or lots if the vehicle occupies multiple lots
        /// </summary>
        public virtual ICollection<ParkingLot> ParkingLots { get; } = new ObservableHashSet<ParkingLot>();
    }
}