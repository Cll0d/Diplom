using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObserver : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CameraController _camertaContoller;

    private void Start()
    {
        _menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu();
        }
    }

    private void ShowMenu()
    {
        if (_menu.activeSelf == false)
        {
            _menu.SetActive(true);
            _playerController.enabled = false;
            _camertaContoller.enabled = false;
        }
        else
        {
            _menu.SetActive(false);
            _playerController.enabled = true;
            _camertaContoller.enabled = true;
        }
    }
    public void Continue()
    {
        _menu.SetActive(false);
        _playerController.enabled = true;
        _camertaContoller.enabled = true;
    }
}
