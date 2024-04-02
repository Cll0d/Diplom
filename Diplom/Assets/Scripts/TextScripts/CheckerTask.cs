using TMPro;
using UnityEngine;

public class CheckerTask : MonoBehaviour
{
    [SerializeField] private TMP_Text _textTask;
    [SerializeField] private string _countRepairNeed;
    [SerializeField] private string _countRepair;
    private string _textTask1;
    private string _textTask2;
    private string _textTask3;
    private string _textTask4; 
    private string _currentTask;
    private int _countCompledetTask;
    public string[] Task = new string[4];
    
    
    private void Awake()
    {
        _textTask1 = $"Заменить колодки {_countRepair} / {_countRepairNeed}";
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
        for (int i = 0; i <= _countCompledetTask && i < Task.Length; i++)
        {
            _currentTask = Task[i];
        }
    }
}