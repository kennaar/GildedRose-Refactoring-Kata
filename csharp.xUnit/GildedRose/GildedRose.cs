using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
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
        if (Items[i].Quality <= 0)
        {
            return;
        }
        
        Items[i].Quality -= GetQualityDegradationValue(i);
    }

    private int GetQualityDegradationValue(int i)
    {
        return Items[i].Name switch
        {
            "Conjured" => 2,
            _ => 1
        };
    }
    
    private void IncreaseQualityOfItem(int i)
    {
        if (Items[i].Quality >= 50)
        {
            return;
        }
        
        Items[i].Quality++;
    }

    private bool IsBackstagePass(int i)
    {
        return Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    private bool IsLegendaryItem(int i)
    {
        return Items[i].Name == "Sulfuras, Hand of Ragnaros";
    }

    private bool IsQualityDecreasingItem(int i)
    {
        return Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert";
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
        return Items[i].Name != "Aged Brie";
    }

    private void DecreaseSellIn(int i)
    {
        if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
        {
            return;
        }

        Items[i].SellIn--;
    }
}