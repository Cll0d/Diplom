using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTask : MonoBehaviour
{
    [SerializeField]private TMP_Text _textTaskMP;
    private string _textTask1 = "-������ �������-������ �������-������ �������-������ �������11";
    private string _textTask2 = "-������ �������-������ �������-������ �������-������ �������22";
    private string _textTask3 = " -������ �������-������ �������-������ �������-������ �������33";
    private string _textTask4 = "-������ �������-������ �������-������ �������-������ �������44";
    public TMP_Text TextTaskMP
    {
        get
        {
            return _textTaskMP;
        }
    }


    private void Awake()
    {
        _textTaskMP.text = _textTask1;
    }


}
