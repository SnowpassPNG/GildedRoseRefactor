using System.Collections.Generic;

namespace GildedRoseKata
{
    public static class GildedRoseStatic
    {
        #region Fields and Constants
        private const string AGED_BRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        private const string CONJURED = "Conjured Mana Cake";

        private const int QUALITY_MIN = 0;
        private const int QUALITY_MAX  = 50;

        private static Item _item;
        #endregion

        public static void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                _item = item;

                switch (_item.Name)
                {
                    case AGED_BRIE:
                        ValidateAgedBrie();
                        break;
                    case SULFURAS:
                        break;
                    case BACKSTAGE_PASSES:
                        ValidateBackstagePasses();
                        break;
                    case CONJURED:
                        ValidateConjured();
                        break;
                    default:
                        ValidateDefaultItems();
                        break;
                }
            }
        }

        #region Private Methods

        #region Default Items Validation
        private static void ValidateDefaultItems()
        {
            // 1 downgrade daily quality
            DowngradeQuality(1);

            // 2 downgrade sale date
            DowngradeSellIn(1);

            // 3 downgrade quality when item expired
            ValidateExpiredItems(1);
        }

        #endregion

        #region Special Items Validation

        private static void ValidateAgedBrie()
        {
            // 1 upgrade daily quality
            UpgradeQuality(1);

            // 2 downgrade Sale date
            DowngradeSellIn(1);

            // 3 quality of aged brie gets better
            ValidateExpiredItems(1, true);
        }

        private static void ValidateBackstagePasses()
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

        private static void ValidateConjured()
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

            // 3 conjured items degrades 2x faster
            ValidateExpiredItems(downgrade);
        }

        #endregion

        #region Common Calculations

        /// <summary>
        /// Validates the Quality of the Item when SellIn gets below min value of zero.
        /// The Quality will upgrade or degrade.
        /// </summary>
        /// <param name="number">The amount of upgrade or downgrade for the Quality</param>
        /// <param name="upgrade">Standard flag for downgrading the Quality. Use true when upgrading the Quality</param>
        private static void ValidateExpiredItems(int number, bool upgrade = false)
        {
            if (_item.SellIn < 0)
            {
                if (upgrade)
                    UpgradeQuality(number);
                else
                    DowngradeQuality(number);
            }
        }
        private static void DowngradeQuality(int number)
        {
            // Quality can never be negative > 0
            if (_item.Quality > QUALITY_MIN)
                _item.Quality -= number;
        }
        private static void UpgradeQuality(int number)
        {
            // Quality can never be greater than < 50
            if (_item.Quality < QUALITY_MAX)
                _item.Quality += number;
        }
        private static void DowngradeSellIn(int number)
        {
            _item.SellIn -= number;
        }

        #endregion

        #endregion
    }
}
