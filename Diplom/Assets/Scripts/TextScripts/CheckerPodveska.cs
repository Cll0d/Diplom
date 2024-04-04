using System;
using UnityEngine;

public class CheckerPodveska : MonoBehaviour
{
    private int _countDetail;
    private int _countBrokenDetail;
    private int _countRepairDeatail;
    private int _countCurrentWorkingDetail;
    private int _countCurrentBrokenDetail;
    public static Action<int,int> onRepair;
    [SerializeField] private DragNDrop DragNDrop;




    private void Start()
    {
        _countRepairDeatail = 0;
        _countDetail = 63;
        if(DragNDrop._podveskaArray2 != null)
        {
            for (int i = 0; i < DragNDrop._podveskaArray2.Count; i++)
            {
                if (DragNDrop._podveskaArray2[i].GetComponent<Item>().IsBroken == true)
                {
                    _countBrokenDetail++;
                }
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
        int _countdet = 61;
       // int _countCurrentBrokenDetail = 0; 
        Debug.Log("������� ��������");
        for (int i = 0; i < DragNDrop._podveskaArray2.Count; i++)
        {
            if (DragNDrop._podveskaArray2[i].GetComponent<Item>().IsBroken == false)
            {
                _countCurrentWorkingDetail++;
            }
        }
        _countCurrentBrokenDetail = _countDetail - _countCurrentWorkingDetail;
        _countRepairDeatail = _countCurrentWorkingDetail - _countdet;

        Debug.Log("��� ��������� " + _countRepairDeatail);
        Debug.Log("����� �������� " + _countDetail);
        Debug.Log("���������� ������� ������" + _countCurrentWorkingDetail);
        Debug.Log("��� ��������� " + _countBrokenDetail);
        Debug.Log("��� ������� ��������� ��������" + _countCurrentBrokenDetail);
        onRepair?.Invoke(_countRepairDeatail, _countBrokenDetail);
        _countCurrentWorkingDetail = 0;
        _countRepairDeatail = 0;
    }
}
