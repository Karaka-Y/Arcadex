using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    Inventory inventory = new Inventory();
    private Item _item;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Item"){
            _item = other.GetComponent<Item>();

            Debug.Log(_item.name);

            Collect();
            other.gameObject.SetActive(false);
            Debug.Log("Item Destroyed");
        }
    }

    private void Collect (){
        Debug.Log("Item picked up");
        inventory.PutItem(_item);
    }
}
