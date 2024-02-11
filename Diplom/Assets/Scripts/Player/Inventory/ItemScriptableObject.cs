using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType {Detail, Instrument};

public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public string itemDescription;

    public GameObject itemPrefab;

    public Sprite icon;
}
