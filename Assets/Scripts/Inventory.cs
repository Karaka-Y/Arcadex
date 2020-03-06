using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> items = new List<Item>();
    
    public void PutItem (Item item){
        items.Add(item);
        
        Debug.Log("Item added to the Inventory");
        Debug.Log(item.name);
        Debug.Log(items.Count);
    }
}
