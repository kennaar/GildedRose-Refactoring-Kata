using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("fixme", Items[0].Name);
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
}