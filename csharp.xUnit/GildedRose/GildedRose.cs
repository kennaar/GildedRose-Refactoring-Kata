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
                    ManageConjured(item);
                    break;
                default:
                    ManageDefault(item);
                    break;
            }
        }
    }

    private void ManageDefault(Item item)
    {
        var amount = item.SellIn <= 0 ? 2 : 1;
        DecreaseQualityOfItem(item, amount);
        DecreaseSellIn(item);
    }

    private void ManageAgedBrie(Item item)
    {
        DecreaseSellIn(item);
        
        var amount = item.SellIn >= 0 ? 1 : 2;
        IncreaseQualityOfItem(item, amount);
    }

    private void ManageConjured(Item item)
    {
        DecreaseSellIn(item);
        
        var amount = item.Quality == 3 ? 2 : 1;
        DecreaseQualityOfItem(item, amount);
    }

    private void ManageBackstagePass(Item item)
    {
        DecreaseSellIn(item);

        if (item.SellIn < 0)
        {
            SetQualityOfItemToMinimum(item);
        }
        else
        {
            var amount = item.SellIn switch
            {
                < 5 => 3,
                < 10 => 2,
                _ => 1,
            };
            IncreaseQualityOfItem(item, amount);
        }
    }

    private void SetQualityOfItemToMinimum(Item item)
    {
        item.Quality = MinimumQuality;
    }

    private void DecreaseQualityOfItem(Item item, int amount = 1)
    {
        item.Quality = Math.Max(MinimumQuality, item.Quality - amount);
    }
    
    private void IncreaseQualityOfItem(Item item, int amount = 1)
    {
        item.Quality = Math.Min(MaximumQuality, item.Quality + amount);
    }
    
    private void DecreaseSellIn(Item item)
    {
        item.SellIn--;
    }
}