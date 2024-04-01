using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuObserver : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CameraController _camertaContoller;
    [SerializeField] private GameObject[] _podveska;
    [SerializeField] private TMP_Text _textButton;
    private bool _isVisible = false;
    private bool _isVisiblePodveska = true;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu();
        }
    }

    private void ShowMenu()
    {
        if (_isVisible == false)
        {

            Pause(); 
        }
        else
        {
            Resume();
        }
    }

    private void Pause()
    {
        _camertaContoller.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _menu.SetActive(true);
        _isVisible = true;
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        _camertaContoller.enabled = true;
        _menu.SetActive(false);
        Time.timeScale = 1f;
        _isVisible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ChangeDifficulty()
    {
        if (_isVisiblePodveska == true)
        {
            for (int i = 0; i < _podveska.Length; i++)
            {
                _podveska[i].GetComponent<MeshRenderer>().enabled = false;
                _textButton.text = "Включить подсказку";
                _isVisible = false;
            }
        }
        if (_isVisiblePodveska == false)
        {
            for (int i = 0; i < _podveska.Length; i++)
            {
                _podveska[i].GetComponent<MeshRenderer>().enabled = true;
                _textButton.text = "Выключить подсказку";
                _isVisible = true;
            }
        }
    }
}
