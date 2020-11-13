using System;
using System.Diagnostics;

namespace Explore.AutoFixture.Model
{
    [DebuggerDisplay("{" + nameof(Id) + "}")]
    public class Image : IEquatable<Image>
    {
        public Guid Id { get; set; }

        public Path Location { get; set; }

        public bool Equals(Image other)
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

            return obj.GetType() == this.GetType() && Equals((Image) obj);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}