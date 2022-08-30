namespace SportsBet.DepthChartManager.Models
{
    public sealed record Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public bool Equals(Player? other)
        {
            if (other is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (Id == other.Id) && string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode() => (Id, Name).GetHashCode();
    }
}