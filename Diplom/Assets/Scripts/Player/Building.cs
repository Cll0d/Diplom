using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject selectedComponent; // ��������� ���������
    [SerializeField] private Vector3 initialPosition;      // ��������� ������� ���������� ����� ���������������
    [SerializeField] private bool isDragging = false;      // ����, �����������, ��� ��������� ���������������

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    // ���������, ��� ������ �� ������� ����������
                    if (hit.collider.gameObject.CompareTag("Component"))
                    {
                        selectedComponent = hit.collider.gameObject;
                        initialPosition = selectedComponent.transform.position;
                        isDragging = true;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                // ���������, ��������� �� ��������� ��� ������
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        // ��������� ��������� �� ������� �����, ���� ���� ����������
                        if (hit.collider.gameObject.CompareTag("Slot"))
                        {
                            selectedComponent.transform.position = hit.collider.gameObject.transform.position;
                            selectedComponent.GetComponent<Rigidbody>().isKinematic = true; // ����� ��������� �� ����� ����� ����������
                        }
                    }
                }

                isDragging = false;
                selectedComponent = null;
            }
        }

        // �������������� ����������
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedComponent.transform.position = new Vector3(mousePosition.x, mousePosition.y, selectedComponent.transform.position.z); 
        }
    }
}
