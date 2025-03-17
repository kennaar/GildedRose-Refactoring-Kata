using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private const int MinimumQuality = 0;
    private const int MaximumQuality = 50;
    // Not thrilled about this name
    private const int QualityVaryValue = 1;
    private const int ConjuredQualityDegradationMultiplier = 2;
    private const string BackstagePassName = "Backstage passes to a TAFKAL80ETC concert";
    private const string LegendaryItemName = "Sulfuras, Hand of Ragnaros";
    private const string AgedBrieName = "Aged Brie";
    private const string ConjuredName = "Conjured";

    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            UpdateQuality(i);

            DecreaseSellIn(i);

            UpdateQualityIfSellInDateReached(i);
        }
    }

    private void UpdateQuality(int i)
    {
        if (IsQualityDecreasingItem(i))
        {
            if (IsLegendaryItem(i))
            {
                return;
            }

            DecreaseQualityOfItem(i);

            return;
        }

        IncreaseQualityOfItem(i);

        if (!IsBackstagePass(i))
        {
            return;
        }
        
        
        // I could turn this into a switch (true), but does that improve anything?
        if (Items[i].SellIn < 11)
        {
            IncreaseQualityOfItem(i);
        }

        if (Items[i].SellIn < 6)
        {
            IncreaseQualityOfItem(i);
        }
    }

    private void DecreaseQualityOfItem(int i)
    {
        if (Items[i].Quality <= MinimumQuality)
        {
            return;
        }
        
        Items[i].Quality -= GetQualityDegradationValue(i);
    }

    private int GetQualityDegradationValue(int i)
    {
        // This comparison should probably be improved, not sure yet what makes an item "conjured"
        var multiplier = Items[i].Name switch
        {
            ConjuredName => ConjuredQualityDegradationMultiplier,
            _ => 1
        };
        
        return QualityVaryValue * multiplier;
    }
    
    private void IncreaseQualityOfItem(int i)
    {
        if (Items[i].Quality >= MaximumQuality)
        {
            return;
        }
        
        Items[i].Quality += QualityVaryValue;
    }

    private bool IsBackstagePass(int i)
    {
        return Items[i].Name == BackstagePassName;
    }

    private bool IsLegendaryItem(int i)
    {
        return Items[i].Name == LegendaryItemName;
    }

    private bool IsQualityDecreasingItem(int i)
    {
        return Items[i].Name != AgedBrieName && Items[i].Name != BackstagePassName;
    }

    private void UpdateQualityIfSellInDateReached(int i)
    {
        if (Items[i].SellIn >= 0)
        {
            return;
        }

        if (!IsRegularQualityIncreasingItem(i))
        {
            IncreaseQualityOfItem(i);

            return;
        }

        if (IsBackstagePass(i))
        {
            Items[i].Quality = 0;

            return;
        }

        if (IsLegendaryItem(i))
        {
            return;
        }

        DecreaseQualityOfItem(i);
    }
    
    private bool IsRegularQualityIncreasingItem(int i)
    {
        return Items[i].Name != AgedBrieName;
    }

    private void DecreaseSellIn(int i)
    {
        if (Items[i].Name == LegendaryItemName)
        {
            return;
        }

        Items[i].SellIn--;
    }
}