using UnityEngine;

//this class used to make inventory list visible for user in-game
public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;

    //items parent - the empty object for all slots
    public Transform itemsParent;
    InventorySlot[] slots;

    //reference to cache inventory's singleton
    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    //method that draws all items that character picks up
    //it uses AddItem function for all items on our list to draw each item icon and count on the slot
    void UpdateUI()
    {
        for (int i = 0; i<slots.Length; i++){
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearItem();
            }
        }
    }

    //show or close inventory
    public void InventoryShow()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
