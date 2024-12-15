namespace GildedRoseKata.Abstraction
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
            // 1 downgrade quality, conjured items degrades 2x faster
            DowngradeQuality(2);
            
            // 2 downgrade Sale date
            DowngradeSellIn(1);

            // 3 it means when SellIn below zero then, besides the normal 2x degrade, again quality will degrade with 2
            ValidateExpiredItems(2);
        }
    }
}
