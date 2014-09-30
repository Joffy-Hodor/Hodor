using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HodorTutor.Infrastructure.Helpers;

namespace HodorTutor.Infrastructure.Domain
{
    public abstract class Entity<TId>
    {
        protected Entity()
        {
        }

        public virtual TId Id { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<TId>;

            if (other == null)
                return false;
            return (other.Id.Equals(this.Id));
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<TId> x, Entity<TId> y)
        {
            return OperatorHelper.Equal(x, y);
        }

        public static bool operator !=(Entity<TId> x, Entity<TId> y)
        {
            return OperatorHelper.Unequal(x, y);
        }
    }
}
