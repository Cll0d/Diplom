using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    public GameObject _camera;
    GameObject currentItem;

    private GameObject selectedComponent;
     private LayerMask _layerMask;

    private float distance = 3f;

    bool canDrag;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) Drag();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
        if (Input.GetKeyDown(KeyCode.T)) Insert();

    }

    void Drag()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, distance))
        {
            if (hit.collider.gameObject.GetComponent<Item>())
            {
                if (canDrag) Drop();
                currentItem = hit.transform.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.transform.localPosition = Vector3.zero;
                currentItem.layer = 2;

                currentItem.transform.localEulerAngles = new Vector3(-20, 180, 0); // Тут настроить положение вещи в руках

                canDrag = true;
            }
        }
    }

    void Drop()
    {
        if (currentItem == null)
        {
            return;
        }
        else
        {
            currentItem.transform.parent = null;
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            canDrag = false;;
            currentItem.layer = 6;
            currentItem = null;
        }
    }

    private void Insert()
    {
        if (canDrag)
        {
            // Проверяем, находится ли компонент над слотом
            RaycastHit hit;
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward * 100);
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 100);
            Debug.Log("1");
            if (Physics.Raycast(ray, out hit, distance))
            {
                Debug.Log("2");
                if (hit.collider != null)
                {
                    Debug.Log("3");
                    // Поместить компонент на позицию слота, если есть совпадение
                    if (hit.collider.gameObject.layer == 8 && hit.collider.GetComponent<Item>().NameDetail == currentItem.GetComponent<Item>().NameDetail)
                    {
                        Debug.Log("4");
                        currentItem.transform.position = hit.collider.gameObject.transform.position;
                        currentItem.transform.rotation = hit.collider.gameObject.transform.rotation;
                        currentItem.GetComponent<Rigidbody>().isKinematic = true; // Чтобы компонент не падал после размещения
                        currentItem.transform.parent = null;
                        currentItem.layer = 6;
                        canDrag = false;
                        currentItem = null;
                    }
                }
            }
        }
    }
}
