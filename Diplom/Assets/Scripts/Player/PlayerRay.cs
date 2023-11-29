using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    private Outline _currentOutline;
    private Detail _currentDetail;

    private void Update()
    {
        DrawRay();
        TriggerRay();
    }

    private void DrawRay()
    {
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);
    }

    private void TriggerRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Detail detail = hit.collider.gameObject.GetComponent<Detail>();
            Outline outline = hit.collider.gameObject.GetComponent<Outline>();
            if (outline)
            {
                EventBus.OnLooked?.Invoke(detail.DetailData.Description);
                EventBus.OnLookedPanel?.Invoke();
                _currentOutline = outline;
                outline.OutlineMode = Outline.Mode.OutlineVisible;
            }
            else 
            {
                if (_currentOutline)
                {
                    EventBus.OnNoLooked?.Invoke();
                    _currentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                    _currentOutline = null;
                }
            }
        }
        else
        {
            if (_currentOutline)
            {
                EventBus.OnNoLooked?.Invoke();
                _currentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                _currentOutline = null;
            }
        }
    }
}
