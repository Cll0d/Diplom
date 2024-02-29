using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTask : MonoBehaviour
{
    [SerializeField]private TMP_Text _textTaskMP;
    private string _textTask1 = "-пример задания-пример задания-пример задания-пример задания11";
    private string _textTask2 = "-пример задания-пример задания-пример задания-пример задания22";
    private string _textTask3 = " -пример задания-пример задания-пример задания-пример задания33";
    private string _textTask4 = "-пример задания-пример задания-пример задания-пример задания44";
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
