using UnityEngine;

public class ObjectInspector : MonoBehaviour
{
    private GameObject _inspectableObject;

    [Header("Button Setup")]
    [SerializeField] private KeyCode _openInspectionButton = KeyCode.F;
    [SerializeField] private KeyCode _closeInspectionButton = KeyCode.Mouse1;

    [Header("Pick up Settings")]
    [SerializeField] private Camera _maincamera;
    [SerializeField] private float _reachDistance = 3f;

    [SerializeField] private InspectionCamera _inspectionCamera;

    [SerializeField] private GameObject _inspectionCanvas;
    [SerializeField] private GameObject _mainCanvas;

    void Update()
    {
        if (_inspectableObject == null)
        {
            Ray ray = _maincamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetKeyDown(_openInspectionButton))
            {
                if (Physics.Raycast(ray, out hit, _reachDistance))
                {
                    if (hit.collider.gameObject.GetComponent<InspectableObject>() != null)
                    {
                        _inspectableObject = Instantiate(hit.collider.gameObject, _inspectionCamera.transform.GetChild(0));
                        _inspectableObject.GetComponent<Rigidbody>().isKinematic = true;
                        InspectableObject inspectableObject = _inspectableObject.GetComponent<InspectableObject>();

                        inspectableObject.transform.localPosition =
                            Vector3.zero + inspectableObject.spawnPositionOffset;
                        inspectableObject.transform.localRotation =
                            Quaternion.Euler(Vector3.zero + inspectableObject.spawnRotationOffset);

                        _inspectionCanvas.SetActive(true);

                        _inspectionCamera.inspectableObject = inspectableObject;
                        _inspectionCamera.gameObject.SetActive(true);

                        _mainCanvas.SetActive(false);
                    }
                }
            }
        }

        if (Input.GetKeyDown(_closeInspectionButton))
        {
            Destroy(_inspectableObject);
            _inspectionCanvas.SetActive(false);
            _inspectionCamera.gameObject.SetActive(false);
            _mainCanvas.SetActive(true);
        }
    }
}
