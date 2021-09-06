using System;

namespace Garage3.Data.Entities
{
    public abstract class Entity
    {
        /// <summary>
        /// The entity's primary key
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// When the entity was created (Local time)
        /// </summary>
        /// <remarks>
        /// The mapping file most likely needs a conversion in place to restore the DateTime.Kind property
        /// when materialising entities from the db. Otherwise local time is assumed.
        /// Typically I would map this as UTC and not Local time but for this exercise to keep it simple
        /// we'll assume local time, though it is concidered bad practise by some.
        /// </remarks>
        public virtual DateTime Created { get; } = DateTime.Now;

        /// <summary>
        /// Rowversion column for implementing optimistic concurrency control with entity framework
        /// </summary>
        public virtual byte[] Timestamp { get; }

        public override string ToString()
        {
            return $"{GetType().Name}#{Id}";
        }
    }
}
