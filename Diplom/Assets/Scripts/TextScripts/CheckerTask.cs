using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckerTask : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTask;
    private static string _textTask1 = "-пример задания-пример задания-пример задания-пример задания11";
    private static string _textTask2 = "-пример задания-пример задания-пример задания-пример задания22";
    private static string _textTask3 = " -пример задания-пример задания-пример задания-пример задания33";
    private static string _textTask4 = "-пример задания-пример задания-пример задания-пример задания44";
    private static string _currentTask;
    private int _countCompledetTask;

    Dictionary<int, string> Task = new Dictionary<int, string>()
    {
        {0,_textTask1},
        {1,_textTask2},
        {2,_textTask3},
        {3,_textTask4},
    };


    private void Awake()
    {
        _currentTask = _textTask1;
        _textTask.text = _currentTask;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckTask();
        }
        _textTask.text = _currentTask;
    }
    private void CheckTask()
    {
        _countCompledetTask++;
        NextTask();
    }

    private void NextTask()
    {
        for (int i = 0; i <= _countCompledetTask && i < 4; i++)
        {
            _currentTask = Task[i];
        }
    }
}