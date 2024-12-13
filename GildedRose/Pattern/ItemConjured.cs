namespace GildedRoseKata.Pattern
{
    internal class ItemConjured : BaseItem
    {

        private readonly Item _item;
        public ItemConjured(Item item) : base(item)
        {
            _item = item;
        }

        public override void Validate()
        {
            // conjured items degrades 2x faster
            int downgrade = 2;

            // we don't want below zero quality
            if (_item.Quality == 1)
                downgrade = 1;

            // 1 downgrade quality 
            DowngradeQuality(downgrade);
            
            // 2 downgrade Sale date
            DowngradeSellIn(1);

            // 3 conjured items degrades 2x faster,
            // it means when SellIn below zero then, besides the normal 2x degrade, again quality will degrade with 2
            ValidateExpiredItems(downgrade);
        }
    }
}
