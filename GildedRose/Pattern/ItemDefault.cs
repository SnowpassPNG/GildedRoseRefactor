namespace GildedRoseKata.Pattern
{
    internal class ItemDefault : BaseItem
    {
        public ItemDefault(Item item) : base(item)
        {}

        public override void Validate()
        {
            DowngradeQuality(1);

            // 2 downgrade sale date
            DowngradeSellIn(1);

            // 3 downgrade quality when item expired
            ValidateExpiredItems(1);
        }
    }
}
