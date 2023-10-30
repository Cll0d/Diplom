using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ObjectInspector : MonoBehaviour
{
    private GameObject _inspectableObject;
    [SerializeField] private CinemachineVirtualCamera _cvc;

    [Header("Button Setup")]
    [SerializeField] private KeyCode _openInspection = KeyCode.F;
    [SerializeField] private KeyCode _closeInspection = KeyCode.Mouse1;

    [Header("Pick up Settings")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _distance = 1.5f;

    //[SerializeField] private InspectionCamera _inspectionCamera;

    [SerializeField] private GameObject _inspectionCanvas;
    [SerializeField] private GameObject _mainCanvas;

    private void Update()
    {
        if (_inspectableObject == null)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetKeyDown(_openInspection))
            {
                if (Physics.Raycast(ray, out hit, _distance))
                {
                    if (hit.collider.gameObject.GetComponent<InspectableObject>() != null)
                    {
                        _inspectableObject = Instantiate(hit.collider.gameObject, _mainCamera.transform.GetChild(0));
                        _inspectableObject.GetComponent<Rigidbody>().isKinematic = true;
                        InspectableObject inspectableObject = _inspectableObject.GetComponent<InspectableObject>();

                        inspectableObject.transform.localPosition = Vector3.zero + inspectableObject.SpawnPositionOffset;
                        inspectableObject.transform.localRotation = Quaternion.Euler(Vector3.zero + inspectableObject.SpawnRotationOffset);

                        _inspectionCanvas.SetActive(true);

                        _mainCanvas.SetActive(false);
                        TurnOffCameraMovement();
                    }
                }
            }
        }

        if (Input.GetKeyDown(_closeInspection))
        {
            Destroy(_inspectableObject);
            _inspectionCanvas.SetActive(false);
            TurnOnCameraMovement();
        }
    }

    private void TurnOffCameraMovement()
    {
        CinemachinePOV pov = _cvc.GetCinemachineComponent<CinemachinePOV>();
        pov.m_HorizontalAxis.m_InputAxisName = "";
        pov.m_VerticalAxis.m_InputAxisName = "";
        pov.m_VerticalAxis.m_InputAxisValue = 0;
        pov.m_HorizontalAxis.m_InputAxisValue = 0;
    }

    private void TurnOnCameraMovement()
    {
        CinemachinePOV pov = _cvc.GetCinemachineComponent<CinemachinePOV>();
        pov.m_HorizontalAxis.m_InputAxisName = "Mouse X";
        pov.m_VerticalAxis.m_InputAxisName = "Mouse Y";
    }
}
