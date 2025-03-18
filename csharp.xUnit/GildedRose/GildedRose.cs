using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const int MinimumQuality = 0;
    private const int MaximumQuality = 50;
    private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
    private const string LegendaryItemName = "Sulfuras, Hand of Ragnaros";
    private const string AgedBrieName = "Aged Brie";
    private const string ConjuredName = "Conjured Mana Cake";

    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            switch (item.Name)
            {
                case LegendaryItemName:
                    break;
                case AgedBrieName:
                    ManageAgedBrie(item);
                    break;
                case BackstagePassName:
                    ManageBackstagePass(item);
                    break;
                case ConjuredName:
                    ManageConjuredName(item);
                    break;
                default:
                    DecreaseQualityOfItem(item);
                    DecreaseSellIn(item);
                    break;
            }
        }
    }

    private void ManageAgedBrie(Item item)
    {
        IncreaseQualityOfItem(item);
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            IncreaseQualityOfItem(item);
        }
    }

    private void ManageConjuredName(Item item)
    {
        if (item.Quality == 3)
        {
            DecreaseQualityOfItem(item);
        }
        
        DecreaseQualityOfItem(item);
        DecreaseSellIn(item);
    }

    private void ManageBackstagePass(Item item)
    {
        IncreaseQualityOfItem(item);
        
        if (item.SellIn < 11)
        {
            IncreaseQualityOfItem(item);
        }

        if (item.SellIn < 6)
        {
            IncreaseQualityOfItem(item);
        }
        
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }

    private void DecreaseQualityOfItem(Item item)
    {
        item.Quality = Math.Max(MinimumQuality, item.Quality - 1);

        if (item.SellIn <= 0 && item.Name != ConjuredName && item.Quality > MinimumQuality)
        {
            item.Quality--;
        }
    }
    
    private void IncreaseQualityOfItem(Item item)
    {
        item.Quality = Math.Min(MaximumQuality, item.Quality + 1);
    }
    
    private void DecreaseSellIn(Item item)
    {
        item.SellIn--;
    }
}