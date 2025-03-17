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
            if (IsNotLegendaryItem(i))
            {
                DecreaseQualityForItem(i);
            }
        } else {
            IncreaseQualityForItem(i);

            if (IsBackstagePass(i))
            {
                if (Items[i].SellIn < 11)
                {
                    IncreaseQualityForItem(i);
                }

                if (Items[i].SellIn < 6)
                {
                    IncreaseQualityForItem(i);
                }
            }
        }
    }

    private void DecreaseQualityForItem(int i)
    {
        if (Items[i].Quality <= 0)
        {
            return;
        }
        
        Items[i].Quality--;
    }
    
    private void IncreaseQualityForItem(int i)
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

    private bool IsNotLegendaryItem(int i)
    {
        return Items[i].Name != "Sulfuras, Hand of Ragnaros";
    }

    private bool IsQualityDecreasingItem(int i)
    {
        return Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert";
    }

    private void UpdateQualityIfSellInDateReached(int i)
    {
        if (Items[i].SellIn < 0)
        {
            if (Items[i].Name != "Aged Brie")
            {
                if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    Items[i].Quality = Items[i].Quality - Items[i].Quality;
                }
            } else {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;
                }
            }
        }
    }

    private void DecreaseSellIn(int i)
    {
        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }
    }
}