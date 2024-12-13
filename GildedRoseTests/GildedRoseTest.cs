using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GildedRoseTests;

[TestFixture]
public class GildedRoseTest
{
    [Test]
    [TestCase("Elixir of the Mongoose", -1, 7)]
    [TestCase("+5 Dexterity Vest", -5, 20)]
    [TestCase("Conjured Mana Cake", -2, 1)]
    public void ValidateExpiredItems_InputItemsWithNegativeSellIn_ReturnsLowerQuality(string name, int day, int q)
    {
        var items = new List<Item> { new Item { Name = name, SellIn = day, Quality = q } };
        GildedRoseStatic.UpdateQuality(items);
        
        Assert.That(items[0].Quality, Is.LessThan(q));
    }

    [Test]
    [TestCase("+5 Dexterity Vest", 10, 20)]
    public void DowngradeQuality_InputNormalItem_ReturnsLowerQuality(string name, int day, int q)
    {
        var items = new List<Item> { new Item { Name = name, SellIn = day, Quality = q } };
        GildedRoseStatic.UpdateQuality(items);

        Assert.That(items[0].Quality, Is.EqualTo(19));
    }

    [TestCase("Aged Brie", 2, 0)]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20)]
    public void UpgradeQuality_InputSpecialItems_ReturnsHigherQuality(string name, int day, int q)
    {
        var items = new List<Item> { new Item { Name = name, SellIn = day, Quality = q } };
        GildedRoseStatic.UpdateQuality(items);

        Assert.That(items[0].Quality, Is.GreaterThan(q));
    }

    [Test]
    [TestCase("Conjured Mana Cake", 2, 6)]
    public void ValidateConjured_InputSpecialItems_ReturnsLessValues(string name, int day, int q)
    {
        var items = new List<Item> { new Item { Name = name, SellIn = day, Quality = q } };
        GildedRoseStatic.UpdateQuality(items);

        Assert.That(items[0].Quality, Is.LessThan(q));
        Assert.That(items[0].SellIn, Is.LessThan(day));
    }


    [Test]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 20)]
    public void ValidateBackstagePasses_InputSpecialItems_ReturnsLessValues(string name, int day, int q)
    {
        var items = new List<Item> { new Item { Name = name, SellIn = day, Quality = q } };
        GildedRoseStatic.UpdateQuality(items);

        Assert.That(items[0].Quality, Is.EqualTo(0));
        Assert.That(items[0].SellIn, Is.LessThan(day));
    }

    [Test]
    [TestCase("Aged Brie", 0, 0)]
    public void ValidateAgedBrie_InputSpecialItems_ReturnsBiggerValues(string name, int day, int q)
    {
        var items = new List<Item> { new Item { Name = name, SellIn = day, Quality = q } };
        GildedRoseStatic.UpdateQuality(items);

        Assert.That(items[0].Quality, Is.EqualTo(2));
        Assert.That(items[0].SellIn, Is.LessThan(day));
    }

    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.Not.EqualTo("fixme"));
    }
}