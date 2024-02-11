using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _sensivity;
    private float _maxYAngel = 90f;

    private float rotationX = 0;

    private void Update()
    {
        ControllerCamera();
    }

    public void ControllerCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * _sensivity);

        rotationX -= mouseY * _sensivity;
        rotationX = Mathf.Clamp(rotationX, -_maxYAngel, _maxYAngel);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
