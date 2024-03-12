using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject selectedComponent; // Выбранный компонент
    [SerializeField] private Vector3 initialPosition;      // Начальная позиция компонента перед перетаскиванием
    [SerializeField] private bool isDragging = false;      // Флаг, указывающий, что компонент перетаскивается

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
                    // Проверяем, что попали по объекту компонента
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
                // Проверяем, находится ли компонент над слотом
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        // Поместить компонент на позицию слота, если есть совпадение
                        if (hit.collider.gameObject.CompareTag("Slot"))
                        {
                            selectedComponent.transform.position = hit.collider.gameObject.transform.position;
                            selectedComponent.GetComponent<Rigidbody>().isKinematic = true; // Чтобы компонент не падал после размещения
                        }
                    }
                }

                isDragging = false;
                selectedComponent = null;
            }
        }

        // Перетаскивание компонента
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedComponent.transform.position = new Vector3(mousePosition.x, mousePosition.y, selectedComponent.transform.position.z); 
        }
    }
}
