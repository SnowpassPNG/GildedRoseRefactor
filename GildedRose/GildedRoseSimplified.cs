using System.Collections.Generic;
namespace GildedRoseKata;

public class GildedRoseSimplified
{
    #region Fields and Constants
    private const string AGED_BRIE = "Aged Brie";
    private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
    private const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
    private const string CONJURED = "Conjured Mana Cake";
    #endregion

    #region C'Tor and Deconstructors
    public GildedRoseSimplified(IList<Item> items)
    {
        Items = items;
    }
    #endregion

    #region Public Methods and Operators

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            // Skip Sulfares
            if (Items[i].Name == SULFURAS)
                continue;

            // Decrease Quality for all normal items
            if (Items[i].Name != AGED_BRIE &&
                Items[i].Name != BACKSTAGE_PASSES &&
                Items[i].Name != CONJURED)
            {
                if (Items[i].Quality > 0)
                    Items[i].Quality -= 1;
            }
            else if (Items[i].Name == CONJURED) // Conjure items age 2x faster
            {
                if (Items[i].Quality > 1)
                    Items[i].Quality -= 2;
            }
            else // Increase Quality for all NON normal items
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    // Bacstage has special rule
                    if (Items[i].Name == BACKSTAGE_PASSES)
                    {
                        if (Items[i].Quality < 50)
                        {
                            if (Items[i].SellIn < 6)
                                Items[i].Quality += 3;
                            else if (Items[i].SellIn < 11)
                                Items[i].Quality += 2;
                        }
                    }
                }
            }

            // Decrease SellIn 
            Items[i].SellIn = Items[i].SellIn - 1;

            // When all items Expired then Quality decrease again.
            // Exception: quality increase for aged brie, and backstage passes
            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name == AGED_BRIE)
                {
                    if (Items[i].Quality < 50)
                        Items[i].Quality += 1;
                }
                else if (Items[i].Name == BACKSTAGE_PASSES)
                {
                    Items[i].Quality -= Items[i].Quality;
                }
                else if (Items[i].Name == CONJURED)
                {
                    if (Items[i].Quality > 1)
                        Items[i].Quality -= 2;
                }
                else
                {
                    if (Items[i].Quality > 0)
                        Items[i].Quality -= 1;
                }
            }
        }
    }

    #endregion

    #region Properties
    public IList<Item> Items { get; private set; }
    #endregion
}