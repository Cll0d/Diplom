using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{

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
        Debug.Log("triggerray");
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("draw");
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable)
            {
                Debug.Log("nenull");
                selectable.Select();
            }
        }
    }
}
