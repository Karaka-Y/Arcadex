﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //item info is a scriptable object that contains all information of the particular item
    public ItemInfo itemInfo;
    public int Id;
    public new string name;
    public string description;
    public Sprite ItemIcon;
    private SpriteRenderer itemRenderer;
    public int count = 1;

    void Start()
    {   
        //initiate all item information from scriptable object
        this.Id = itemInfo.Id;
        this.name = itemInfo.name;
        this.description = itemInfo.description;
        this.ItemIcon = itemInfo.ItemIcon;
        
        itemRenderer = GetComponent<SpriteRenderer>();
        itemRenderer.sprite = this.ItemIcon;
        itemRenderer.sortingOrder = 5;
    }
}
