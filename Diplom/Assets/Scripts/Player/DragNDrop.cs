using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragNDrop : MonoBehaviour
{
    public GameObject _camera;
    GameObject currentItem;
    [SerializeField] private CheckerPodveska _podveska;
    [SerializeField] List<GameObject> _podveskaArray2;
    CheckerPodveska chekpod;

    [SerializeField]private GameObject _podveskaVis;
    public static Action onInserted;


    private float distance = 3f;
    bool canDrag;

    private void Start()
    {
       
    }

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
            if (hit.collider.gameObject.GetComponent<Item>() && hit.collider.gameObject.layer == 6)
            {
                if (canDrag)
                {
                    Drop();
                }
                if (hit.collider.gameObject.transform.parent == _podveskaVis.transform)
                {
                    Debug.Log("подвеска");
                   // GameObject disk = GameObject.Find("347 disk.001");
                    int index = _podveskaArray2.IndexOf(GameObject.Find("347 disk.001"));
                    for(int i = 0; i <  _podveskaArray2.Count; i++)
                    {
                        Debug.Log(i);
                    }

                    if (index != -1)
                    {
                        Debug.Log("Индекс объекта в списке: " + index);
                    }
                    else
                    {
                        Debug.Log("Объект не найден в списке");
                    }
                    Debug.Log(index);
                    //_podveskaArray2.RemoveAt(index);
                    currentItem = hit.transform.gameObject;
                    currentItem.GetComponent<Rigidbody>().isKinematic = true;
                    currentItem.transform.parent = transform;
                    currentItem.transform.localPosition = Vector3.zero;
                    currentItem.layer = 2;

                    currentItem.transform.localEulerAngles = new Vector3(-20, 180, 0); // Тут настроить положение вещи в руках

                    canDrag = true;
                }
                else
                {
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
            currentItem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            currentItem.layer = 6;
            currentItem = null;
        }
    }

    private void Insert()
    {
        if (canDrag)
        {
            RaycastHit hit;
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward * 100);
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 100);
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.layer == 8 && hit.collider.GetComponent<Item>().NameDetail == currentItem.GetComponent<Item>().NameDetail)
                    {
                        currentItem.transform.position = hit.collider.gameObject.transform.position;
                        currentItem.transform.rotation = hit.collider.gameObject.transform.rotation;
                        currentItem.GetComponent<Rigidbody>().isKinematic = true;
                        currentItem.transform.parent = _podveska.transform;
                        currentItem.layer = 6;
                        canDrag = false;
                        currentItem = null;
                        onInserted?.Invoke();
                    }
                }
            }
        }
    }
}
