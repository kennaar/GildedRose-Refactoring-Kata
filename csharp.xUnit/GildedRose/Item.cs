using System;

namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }

    private int _quality;
    public int Quality
    {
        get => _quality;
        set => _quality = Math.Clamp(value, 0, int.MaxValue);
    }
    
    public void DecreaseQuality(int amount = 1)
    {
        Quality -= amount;
    }
    
    public void IncreaseQuality(int amount = 1)
    {
        Quality += amount;
    }
}