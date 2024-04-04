using System;
using TMPro;
using UnityEngine;

public class CheckerTask : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTask;
    //[SerializeField] private string _countRepairNeed;
    //[SerializeField] private string _countRepair = "0";
    private string _textTask1;
    private string _textTask2;
    private string _textTask3;
    private string _textTask4; 
    private string _currentTask;
    private int _countCompledetTask;
    public string[] Task = new string[4];
    
    
    private void Awake()
    {
        //_countRepairNeed = "2";
        _textTask1 = $"Заменить диск {0} / {2}";
        _textTask2 = "-пример задания-пример задания-пример задания-пример задания22";
        _textTask3 = "-пример задания-пример задания-пример задания-пример задания33";
        _textTask4 = "-пример задания-пример задания-пример задания-пример задания4";
        _currentTask = _textTask1;
        _textTask.text = _currentTask;
        Task[0] = _textTask1;
        Task[1] = _textTask2;
        Task[2] = _textTask3;
        Task[3] = _textTask4;
    }

    private void OnEnable()
    {
        CheckerPodveska.onRepair += Text;
    }

    private void OnDisable()
    {
        CheckerPodveska.onRepair -= Text;
    }
   
    private void CheckTask()
    {
        _countCompledetTask++;
        NextTask();
    }

    private void NextTask()
    {
        for (int i = 0; i < Task.Length; i++)
        {
            _currentTask = Task[i];
        }
    }

    private void Text(int a,int b)
    {
        a.ToString();
        b.ToString();
        _currentTask = $"Заменить диск {a} / {b}";
        _textTask.text = _currentTask;
        Convert.ToInt32(a);
        Convert.ToInt32(b);
        if(a == b)
        {
            CheckTask();
        }
    }


}