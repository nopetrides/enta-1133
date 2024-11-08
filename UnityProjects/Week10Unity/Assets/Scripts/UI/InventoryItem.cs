using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Example class for displaying an item
/// </summary>
public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Image ItemIcon;
    [SerializeField] private Text ItemName;

    public void Setup(ItemData itemData)
    {
        switch (itemData.ItemRarity)
        {
            case ItemData.Rarity.Common:
                ItemIcon.color = Color.white;
                break;
            case ItemData.Rarity.Rare:
                ItemIcon.color = Color.blue;
                break;
        }
        ItemName.text = itemData.ItemName;
    }

}