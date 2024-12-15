using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    private static int days = 12;

    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");
        try
        {
            SetDays(args);
            CheckDaily();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    /// <summary>
    /// Prints the items to the screen 
    /// </summary>
    private static void CheckDaily()
    {
        var items = GetItems();
        //var app = new GildedRose(items);

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("{0, 60}", "-------- day " + i + " --------");
            Console.WriteLine("{0,-60} {1,-20} {2,-20}", nameof(Item.Name), nameof(Item.SellIn), nameof(Item.Quality));

            for (var j = 0; j < items.Count; j++)
                Console.WriteLine("{0,-60} {1,-20} {2,-20}", items[j].Name, items[j].SellIn, items[j].Quality);

            Console.WriteLine("");
            GildedRoseAbstract.UpdateQuality(items);
            //GildedRoseStatic.UpdateQuality(items);
            //app.UpdateQuality();
        }
    }

    /// <summary>
    /// Creates an initial list of items with values.
    /// </summary>
    /// <returns>Return a list of items.</returns>
    private static IList<Item> GetItems()
    {
        IList<Item> items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49},
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 30}
        };

        return items;
    }

    private static void SetDays(string[] args)
    {
        if (args.Length > 0)
            days = int.Parse(args[0]) + 1;
    }
}