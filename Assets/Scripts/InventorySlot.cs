using UnityEngine;
using UnityEngine.UI;

//the class represents incentory slot in UI of inventory
//it show an image of the item it contains and amount of items in stack
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Text count;

//I get information that is shown in slot from Item object, so this object is passed to AddItem method
//this method called from inventory UI to represent all items that character has in his inventory list
    public void AddItem(Item newItem){
        item = newItem;
        icon.sprite = item.ItemIcon;

        //inventory slots have disabled image component at start (becouse basic image is a white rectangle)
        //when we put item in the inventory we make image component visible, becouse items have icon with transparent background
        icon.enabled = true;
        count.enabled = true;
        count.text = newItem.count.ToString();
    }
    //this method is used to show empty slot
    public void ClearItem(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        count.enabled = false;
    }
}
