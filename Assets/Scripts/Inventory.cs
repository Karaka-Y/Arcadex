using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using UnityEngine;

//inventory class for game
public class Inventory : MonoBehaviour
{
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 20; //maximum inventory capacity
    public int stackCapacity = 5; //define how many items of the same type can be stacked as one item
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
    
    //methot that chunk items to stacks (like in World of Warcraft or another RPG)
    //character picks some items and then they adds to the inventory as one or several stacks (or only update existent stacks)
    public bool PutItem (Item item){
        var selectedItems = from i in items where ((i.Id == item.Id) && (i.count < stackCapacity)) select i;
        foreach(var selectedItem in selectedItems){
            int freeSpace = stackCapacity - selectedItem.count;
            //if we picked less items than place to make full stack we just add them to existent stack and ignore item component
            if(item.count <= freeSpace){
                selectedItem.count += item.count;
                item.count = 0;
                break;
            }
            //if we picked more items than free space we fill all free space in all not full stacked items and go forward with the remaining items
            else{
                selectedItem.count += freeSpace;
                item.count -= freeSpace;
            }
        }
        //so now we filled all existent items to full stacks and we have some items after it
        //then, we cut them to another stacks (if we have more items than one stack we create new stacks and add them to the inventory)
        //if we have less items that is needed to create a stack we add this items to the inventory
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
        //if PutItem method is called all observers will be notified
        if (onItemChangedCallback != null){

        onItemChangedCallback.Invoke();

        }
        Debug.Log("Item added to the Inventory, Name: " + item.name);
        return true;
    }
    
    //instantiate item to put it to the inventory
    //item is set inactive to prevent its picking up
    private Item NewItemCreator(Item _item, int count){
        Item newItem = Instantiate(_item).GetComponent<Item>();
        newItem.gameObject.SetActive(false);
        newItem.count = count;
        return newItem;
    }
    
    //chunk all picked up items to stacks
    private void ChunkItems(Item item, out decimal stackOvercount){
        decimal itemCount = (decimal)item.count;
        stackOvercount = Truncate(itemCount / (decimal)stackCapacity);
        Debug.Log("stackOvercount = " + stackOvercount);
        item.count = item.count % stackCapacity;
    }
}
