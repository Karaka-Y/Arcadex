using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that make collision processing
public class ItemCollect : MonoBehaviour
{
    private Item _item;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Item"){
            _item = other.GetComponent<Item>();

            Debug.Log("Interact with Item, Item Name: " + _item.name);

            Collect();
        }
    }
    private void Collect (){
        //wasPickedUp - bool variable that helps to ignore items when inventory is full
        bool wasPickedUp = Inventory.instance.PutItem(_item);
        if(wasPickedUp){
            Debug.Log("Item picked up");
            _item.gameObject.SetActive(false);
            Debug.Log("Item removed from the scene");
            }
    }
}
