using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    private SpriteRenderer itemRenderer;
    // Start is called before the first frame update
    void Start()
    {   
        itemRenderer = GetComponent<SpriteRenderer>();
        itemRenderer.sprite = item.ItemIcon;
        itemRenderer.sortingOrder = 5;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
