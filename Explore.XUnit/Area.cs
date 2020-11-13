using System;

namespace Explore.XUnit
{
    public class Area : IEquatable<Area>
    {
        public Guid Id { get; set; }

        public bool Equals(Area other)
        {
            if (ReferenceEquals(null, other)) 
                return false;

            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;

            if (ReferenceEquals(this, obj)) 
                return true;
            
            return obj.GetType() == GetType() && Equals((Area) obj);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}