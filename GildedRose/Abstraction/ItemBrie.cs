namespace GildedRoseKata.Abstraction
{
    internal class ItemBrie : BaseItem
    {
        public ItemBrie(Item item) : base(item)
        {
        }

        public override void Validate()
        {
            // 1 upgrade daily quality
            UpgradeQuality(1);

            // 2 downgrade Sale date
            DowngradeSellIn(1);

            // 3 quality of aged brie gets better
            ValidateExpiredItems(1, true);
        }
    }
}