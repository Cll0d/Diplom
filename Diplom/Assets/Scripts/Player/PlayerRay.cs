using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    private Outline _currentOutline;

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
            Outline outline = hit.collider.gameObject.GetComponent<Outline>();
            if (outline)
            {
                _currentOutline = outline;
                outline.OutlineMode = Outline.Mode.OutlineVisible;
            }
            else 
            {
                if (_currentOutline)
                {
                    _currentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                    _currentOutline = null;
                }
            }
        }
        else
        {
            if (_currentOutline)
            {
                _currentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                _currentOutline = null;
            }
        }
    }
}
