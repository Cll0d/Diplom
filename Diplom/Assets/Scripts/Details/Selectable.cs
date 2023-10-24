using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public void Select()
    {
        GetComponentInChildren<Renderer>().material.color = Color.yellow;
    }

    public void Deselect()
    {
        GetComponentInChildren<Renderer>().material.color = Color.gray;
    }
}
