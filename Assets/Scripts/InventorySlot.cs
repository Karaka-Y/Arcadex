using UnityEngine;
using UnityEngine.UI;

//the class represents incentory slot in UI of inventory
//it shows an image of the item it contains and amount of items in stack
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Text count;

//this method called from inventory UI to represent all items that character has in his inventory list
    public void AddItem(Item newItem){
        item = newItem;
        icon.sprite = item.ItemIcon;
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
