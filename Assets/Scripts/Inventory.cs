using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using UnityEngine;

//inventory class for game
public class Inventory : MonoBehaviour
{
    //when item picked up we might have some things to be updated, such as UI
    public delegate void OnItemChanged();
    //event
    public OnItemChanged onItemChangedCallback;
    public int space = 20;
    public int stackCapacity = 5;
    private decimal stackOvercount = 0;
    //at this time only one inventory can be in the game, character's inventory
    //so i use singleton to make it and to get easy acess to the inventory from another classes
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
    
    //methot that chung items to stacks (like in World of Warcraft or another RPG)
    //character picks some items and then they adds to the inventory as one or some stacks (or only update existent stacks)
    public bool PutItem (Item item){
        //i get all not fulled stacks of the same item in the inventory
        var selectedItems = from i in items where ((i.Id == item.Id) && (i.count < stackCapacity)) select i;
        //if this items have enough place we add items from those we picked up to this not filled to fill them completely
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
        if (onItemChangedCallback != null){

        onItemChangedCallback.Invoke();

        }
        Debug.Log("Item added to the Inventory, Name: " + item.name);
        return true;
    }
    //this method created becouse i don't know how to get deep copy of the component
    //I instantiate new item (copy all game object and get his component)
    //of course I make this item inactive, becouse i dont want to pick up it after creating
    private Item NewItemCreator(Item _item, int count){
        Item newItem = Instantiate(_item).GetComponent<Item>();
        newItem.gameObject.SetActive(false);
        newItem.count = count;
        return newItem;
    }
    //a little mathematics to recycle all items that we picked befor adding to the inventory
    //stackovercount shows how much times we exceed stack count (if stack capacity = 20 and we have picked up 106 items - stackovercount
    //will be equal to 5 - that mean we need to create five new stacks in the inventory and add new item with count equals to 6)
    private void ChunkItems(Item item, out decimal stackOvercount){
        decimal itemCount = (decimal)item.count;
        stackOvercount = Truncate(itemCount / (decimal)stackCapacity);
        Debug.Log("stackOvercount = " + stackOvercount);
        item.count = item.count % stackCapacity;
    }
}
