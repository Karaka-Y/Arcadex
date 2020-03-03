using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private GameObject _item;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Item"){
            _item = other.gameObject;
            Collect();
            _item.SetActive(false);
        }
    }

    private void Collect (){
        Debug.Log("Item picked up");
    }
}
