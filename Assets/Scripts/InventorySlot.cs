using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Text count;


    public void AddItem(Item newItem){
        item = newItem;
        icon.sprite = item.ItemIcon;
        icon.enabled = true;
        count.enabled = true;
        count.text = newItem.count.ToString();
    }
    public void ClearItem(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        count.enabled = false;
    }
}
