using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    public GameObject _camera;
    GameObject currentItem;

    private GameObject selectedComponent;
    [SerializeField] private LayerMask _layerMask;

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
            currentItem = null;
        }
    }

    private void Insert()
    {
        if (canDrag)
        {
            // Проверяем, находится ли компонент над слотом
            RaycastHit hit;
            Debug.Log("1");
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _layerMask))
            {
                Debug.Log("2");
                if (hit.collider != null)
                {
                    Debug.Log("3");
                    // Поместить компонент на позицию слота, если есть совпадение
                    Debug.Log("4");
                    currentItem.GetComponent<Rigidbody>().isKinematic = true; // Чтобы компонент не падал после размещения
                    currentItem.transform.position = hit.collider.gameObject.transform.position;
                    currentItem.transform.parent = null;
                    canDrag = false;
                    currentItem = null;
                }
            }
        }
    }
}
