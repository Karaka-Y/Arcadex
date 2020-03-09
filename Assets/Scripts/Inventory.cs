using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 20;
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
        if (items.Count >= space){
            Debug.Log("Not enough room in Inventory");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null){

        onItemChangedCallback.Invoke();

        }
        Debug.Log("Item added to the Inventory, Name: " + item.name);
        return true;
    }

}
