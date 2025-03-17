using System;

namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }

    protected int _quality;
    public int Quality
    {
        get => _quality;
        set => _quality = Math.Clamp(value, 0, int.MaxValue);
    }
    
    public virtual void DecreaseQuality(int amount = 1)
    {
        Quality -= amount;
    }
    
    public virtual void IncreaseQuality(int amount = 1)
    {
        Quality += amount;
    }

    public virtual void DecreaseSellIn(int amount = 1)
    {
        SellIn -= amount;
    }
}

public class LegendaryItem : Item
{
    public LegendaryItem(string name, int sellIn)
    {
        _quality = 80;
        Name = name;
        SellIn = sellIn;
    }

    public override void DecreaseQuality(int amount = 1)
    {
    }

    public override void IncreaseQuality(int amount = 1)
    {
    }

    public override void DecreaseSellIn(int amount = 1)
    {
    }

    public new int Quality
    {
        get => _quality;
        protected set { }
    }

    public new int SellIn
    {
        get => base.SellIn;
        set => base.SellIn = value;
    }

    public new string Name
    {
        get => base.Name;
        set => base.Name = value;
    }
}