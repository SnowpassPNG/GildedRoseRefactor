namespace GildedRoseKata.Abstraction
{
    public abstract class BaseItem
    {
        private const int QUALITY_MIN = 0;
        private const int QUALITY_MAX = 50;

        private Item _item;
        
        protected BaseItem(Item item) 
        {
            _item = item;
        }

        public abstract void Validate();
        protected void ValidateExpiredItems(int number, bool upgrade = false)
        {
            if (_item.SellIn < 0)
            {
                if (upgrade)
                    UpgradeQuality(number);
                else
                    DowngradeQuality(number);
            }
        }
        protected void DowngradeQuality(int number)
        {
            // Quality can never be negative > 0
            if (_item.Quality > QUALITY_MIN)
                _item.Quality -= number;
            else 
                _item.Quality = QUALITY_MIN;
        }
        protected void UpgradeQuality(int number)
        {
            // Quality can never be greater than < 50
            if (_item.Quality < QUALITY_MAX)
                _item.Quality += number;
            else
                _item.Quality = QUALITY_MAX;
        }
        protected void DowngradeSellIn(int number)
        {
            _item.SellIn -= number;
        }
    }
}
