/// <summary>
/// Example class for testing some item data
/// </summary>
public class ItemData
{
    public ItemData(string itemName, Rarity rarity)
    {
        ItemName = itemName;
        ItemRarity = rarity;
    }
    public enum Rarity
    {
        Common,
        Rare
    }

    public string ItemName;

    public Rarity ItemRarity;

    // dice value... etc (not included for lecture - you should already have this!)
}
