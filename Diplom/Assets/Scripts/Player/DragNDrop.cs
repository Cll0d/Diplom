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

                currentItem.transform.localEulerAngles = new Vector3(-20, 180, 0); // ��� ��������� ��������� ���� � �����

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
            canDrag = false;
            currentItem = null;
        }
    }

    private void Insert()
    {
        if (canDrag)
        {
            // ���������, ��������� �� ��������� ��� ������
            RaycastHit hit;
            Debug.Log("1");
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit))
            {
                Debug.Log("2");
                if (hit.collider != null)
                {
                    Debug.Log("3");
                    // ��������� ��������� �� ������� �����, ���� ���� ����������
                    if (hit.collider.gameObject.CompareTag("Slot"))
                    {
                        Debug.Log("4");
                        selectedComponent.GetComponent<Rigidbody>().isKinematic = true; // ����� ��������� �� ����� ����� ����������
                        selectedComponent.transform.position = hit.collider.gameObject.transform.position;
                    }
                }
            }

            canDrag = false;
            selectedComponent = null;
        }
    }
}
