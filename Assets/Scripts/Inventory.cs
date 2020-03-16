using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 20;
    public int stackCapacity = 5;
    private decimal stackOvercount = 0;
    #region Singleton
    public static Inventory instance;
    void Awake(){
        if (instance != null){
            Debug.LogWarning("More than one inventory instance found");
            return;
        }
        instance = this;
    }
    #endregion
    public List<Item> items = new List<Item>();
    
    public bool PutItem (Item item){
        var selectedItems = from i in items where ((i.Id == item.Id) && (i.count < stackCapacity)) select i;
        foreach(var selectedItem in selectedItems){
            int freeSpace = stackCapacity - selectedItem.count;
            if(item.count <= freeSpace){
                selectedItem.count += item.count;
                item.count = 0;
                break;
            }
            else{
                selectedItem.count += freeSpace;
                item.count -= freeSpace;
            }
        }
        ChunkItems(item, out stackOvercount);
        if(stackOvercount > 0){
            for(int i = 0; i<stackOvercount; i++){
            items.Add(NewItemCreator(item, stackCapacity));
            }
        }
        if(item.count != 0){
        items.Add(item);}
        
        if (items.Count >= space){
            Debug.Log("Not enough room in Inventory");
            return false;
        }
        if (onItemChangedCallback != null){

        onItemChangedCallback.Invoke();

        }
        Debug.Log("Item added to the Inventory, Name: " + item.name);
        return true;
    }
    private Item NewItemCreator(Item _item, int count){
        Item newItem = Instantiate(_item).GetComponent<Item>();
        newItem.gameObject.SetActive(false);
        newItem.count = count;
        return newItem;
    }
    private void ChunkItems(Item item, out decimal stackOvercount){
        decimal itemCount = (decimal)item.count;
        stackOvercount = Truncate(itemCount / (decimal)stackCapacity);
        Debug.Log("stackOvercount = " + stackOvercount);
        item.count = item.count % stackCapacity;
    }
}
