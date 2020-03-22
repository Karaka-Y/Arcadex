using UnityEngine;

//this class used to mage inventory list visible for user in-game
public class InventoryUI : MonoBehaviour
{
    //reference to the UI panel that contains inventory
    public GameObject inventoryPanel;

    //items parent - the empty object for all slots, used to get all child slots by "GetComponentsInChildren"
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

    // Update is called once per frame
    void Update()
    {
        
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
    //method for inventory button
    public void InventoryShow()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
