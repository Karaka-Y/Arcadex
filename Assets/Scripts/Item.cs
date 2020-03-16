using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemInfo itemInfo;
    public int Id;
    public new string name;
    public string description;
    public Sprite ItemIcon;
    private SpriteRenderer itemRenderer;
    public int count = 1;
    // Start is called before the first frame update
    void Start()
    {   
        this.Id = itemInfo.Id;
        this.name = itemInfo.name;
        this.description = itemInfo.description;
        this.ItemIcon = itemInfo.ItemIcon;
        
        itemRenderer = GetComponent<SpriteRenderer>();
        itemRenderer.sprite = this.ItemIcon;
        itemRenderer.sortingOrder = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
