using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemScriptableObject item;

    [SerializeField]private string _nameDetail;
    public int Amount;
    public bool IsBroken;

    public string NameDetail { get { return _nameDetail; } }
}

