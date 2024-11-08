using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // This will be the object where a layout group is attached, or the "content" object of a scroll view
    [SerializeField] private Transform InventoryContentParent;
    [SerializeField] private InventoryItem ItemExamplePrefab;

    List<ItemData> _fakeInventoryForTesting = new();

    List<InventoryItem> _inventoryItemInstances = new();

    private void Awake()
    {
        // Create some example items for testing
        _fakeInventoryForTesting.Add(new ItemData("Longsword", ItemData.Rarity.Common));
        {
            _fakeInventoryForTesting.Add(new ItemData("Dagger", ItemData.Rarity.Rare));
            _fakeInventoryForTesting.Add(new ItemData("Longsword", ItemData.Rarity.Rare));
            _fakeInventoryForTesting.Add(new ItemData("Health Potion", ItemData.Rarity.Common));
            _fakeInventoryForTesting.Add(new ItemData("Longsword", ItemData.Rarity.Common));
            _fakeInventoryForTesting.Add(new ItemData("Dagger", ItemData.Rarity.Rare));
            _fakeInventoryForTesting.Add(new ItemData("Longsword", ItemData.Rarity.Rare));
            _fakeInventoryForTesting.Add(new ItemData("Health Potion", ItemData.Rarity.Common));
            _fakeInventoryForTesting.Add(new ItemData("Longsword", ItemData.Rarity.Common));
            _fakeInventoryForTesting.Add(new ItemData("Dagger", ItemData.Rarity.Rare));
            _fakeInventoryForTesting.Add(new ItemData("Longsword", ItemData.Rarity.Rare));
            _fakeInventoryForTesting.Add(new ItemData("Health Potion", ItemData.Rarity.Common));
            _fakeInventoryForTesting.Add(new ItemData("Longsword", ItemData.Rarity.Common));
            _fakeInventoryForTesting.Add(new ItemData("Dagger", ItemData.Rarity.Rare));
            _fakeInventoryForTesting.Add(new ItemData("Longsword", ItemData.Rarity.Rare));
            _fakeInventoryForTesting.Add(new ItemData("Health Potion", ItemData.Rarity.Common));
        } // etc, 16 items
    }

    private void OnEnable()
    {
        foreach(ItemData item in _fakeInventoryForTesting)
        {
            var inventoryItem = Instantiate(ItemExamplePrefab, InventoryContentParent);
            inventoryItem.Setup(item);
            _inventoryItemInstances.Add(inventoryItem);
        }
    }

    private void OnDisable()
    {
        // Since OnEnable adds objects to the transform, we need to remove those before we add more
        foreach(InventoryItem item in _inventoryItemInstances)
        {
            Destroy(item.gameObject);
        }
        // each value in the list will now be a null reference
        _inventoryItemInstances.Clear();
    }

    public void ButtonContinue()
    {
        // add code here, unpause the game
    }

    public void ButtonQuit()
    {
        // add code here
        // maybe have more buttons, one for main menu, one for close game?
    }
}
