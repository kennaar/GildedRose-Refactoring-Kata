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
    
    // [Theory]
    // [InlineData(-1, -1)]
    // [InlineData(0, 0)]
    // public void TheLegendaryItemSellInNeverChanges(int sellIn, int expectedSellIn)
    // {
    //     IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = sellIn } };
    //     GildedRose app = new GildedRose(items);
    //     app.UpdateQuality();
    //     Assert.Equal(expectedSellIn, items[0].SellIn);
    // }
}