using GildedRoseKata.Abstraction;
using System.Collections.Generic;

namespace GildedRoseKata
{
    internal static class GildedRoseAbstract
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        private const string CONJURED = "Conjured Mana Cake";

        public static void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                switch (item.Name)
                {
                    case AGED_BRIE:
                         new ItemBrie(item).Validate();
                        break;
                    case SULFURAS:
                        break;
                    case BACKSTAGE_PASSES:
                        new ItemBackstage(item).Validate();
                        break;
                    case CONJURED:
                        new ItemConjured(item).Validate();
                        break;
                    default:
                        new ItemDefault(item).Validate();
                        break;
                }
            }
        }
    }
}