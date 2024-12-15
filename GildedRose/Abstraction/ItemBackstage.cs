namespace GildedRoseKata.Abstraction
{
    internal class ItemBackstage : BaseItem
    {
        private readonly Item _item;
        public ItemBackstage(Item item) : base(item)
        {
            _item = item;
        }

        public override void Validate()
        {
            // 1 upgrade daily quality
            UpgradeQuality(1);

            // special rule for Backstage passes
            if (_item.SellIn < 6)
                UpgradeQuality(3);
            else if (_item.SellIn < 11)
                UpgradeQuality(2);

            // 2 downgrade Sale date
            DowngradeSellIn(1);

            // 3 quality of backstage is zero after concert
            ValidateExpiredItems(_item.Quality);
        }
    }
}
