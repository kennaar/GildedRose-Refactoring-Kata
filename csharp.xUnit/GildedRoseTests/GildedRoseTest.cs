using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void TheNameDoesNotChangeAfterUpdatingTheQuality()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal("foo", items[0].Name);
    }
    
    /// <summary>
    /// @TODO: Is Item.Quality a percentage? Then 100 is the max, and we should clamp to 100
    /// </summary>
    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, 100)]
    [InlineData(-1, 0)]
    public void TheQualityIsNeverNegative(int quality, int expectedQuality)
    {
        Item item = new Item { Name = "foo", SellIn = 0, Quality = quality };
        
        Assert.True(item.Quality >= 0);
        Assert.Equal(expectedQuality, item.Quality);
    }
    
    [Theory]
    [InlineData(-1, -1)]
    [InlineData(0, 0)]
    public void TheLegendaryItemSellInNeverChanges(int sellIn, int expectedSellIn)
    {
        IList<Item> items = new List<Item> { new LegendaryItem("foo", sellIn) };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(expectedSellIn, items[0].SellIn);
    }
}