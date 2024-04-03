using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject icon;

    public Transform inventory;

    private Camera _mainCamera;

    private float reachDistance = 3f;

    public List<InventorySlot> slot = new List<InventorySlot>();

    void Start()
    {
        _mainCamera = Camera.main;

        for (int i = 0; i < inventory.childCount; i++)
        {
            if (inventory.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slot.Add(inventory.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    private void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().Amount);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }
    }

    public void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slot)
        {
            if (slot.item == _item)
            {
                slot.amount = _amount;
                return;
            }
        }
        foreach (InventorySlot slot in slot)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                break;
            }
        }
    }

    public void DropItem()
    {
        foreach (InventorySlot slot in slot)
        {
            if (slot.isEmpty == false)
            {
                slot.item = null;
                slot.amount = 0;
                slot.isEmpty = true;
                slot.SetIcon(null);
                icon.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
        }
    }
}
