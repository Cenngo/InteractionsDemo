namespace InteractionsDemo
{
    public class PerfectlyRealisticDB
    {
        public record DbItem(Guid Id, string Name);

        private static readonly List<DbItem> _items = new List<DbItem>
        {
            new DbItem(Guid.NewGuid(), "apple"),
            new DbItem(Guid.NewGuid(), "blueberry"),
            new DbItem(Guid.NewGuid(), "cherry"),
            new DbItem(Guid.NewGuid(), "dragon fruit"),
            new DbItem(Guid.NewGuid(), "elderberry"),
            new DbItem(Guid.NewGuid(), "fig"),
            new DbItem(Guid.NewGuid(), "grapes"),
        };

        public IReadOnlyCollection<DbItem> Items => _items;
    }
}
