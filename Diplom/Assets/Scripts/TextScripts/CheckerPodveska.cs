using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPodveska : MonoBehaviour
{
    [SerializeField] public List<GameObject> _podveskaArray;
    private int _countDetail;
    private int _countBrokenDetail;
    private int _countRepairDeatail;
    private int _countCurrentWorkingDetail;
    public static Action<int> onRepair;




    private void Start()
    {

        
        _countRepairDeatail = 0;
        _countDetail = 63;
        for (int i = 0; i < _podveskaArray.Count; i++)
        {
            if (_podveskaArray[i].GetComponent<Item>().IsBroken == true)
            {
                _countBrokenDetail++;
            }
        }
    }


    private void OnEnable()
    {
        DragNDrop.onInserted += Check;
    }

    private void OnDisable()
    {
        DragNDrop.onInserted -= Check;
    }

    private void Check()
    {
        int _countCurrentBrokenDetail = 0; 
        Debug.Log("Событие работает");
        for (int i = 0; i < _podveskaArray.Count; i++)
        {
            if (_podveskaArray[i].GetComponent<Item>().IsBroken == true)
            {
                _countCurrentBrokenDetail++;
            }
            else if(_podveskaArray[i].GetComponent<Item>().IsBroken == false)
            {
                _countCurrentWorkingDetail++;
            }
        }
        _countRepairDeatail = _countDetail - _countCurrentWorkingDetail;
        Debug.Log("кол починеных " + _countRepairDeatail);
        Debug.Log("всего детайлей " + _countDetail);
        Debug.Log("Количество рабчих сейчас" + _countCurrentWorkingDetail);
        Debug.Log("кол сломанных " + _countBrokenDetail);
        Debug.Log("кол текущих сломанных детайлей" + _countCurrentBrokenDetail);
    }
}
