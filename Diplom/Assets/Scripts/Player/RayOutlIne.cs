using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class RayOutlIne : MonoBehaviour
{
    [SerializeField]private Transform transformCamera;
    [SerializeField] private float _distance = 8;
    private Outline _cuerrentOutline;

    private void Update()
    {
        OutlineObject();
    }
    void OutlineObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(transformCamera.transform.position, transformCamera.transform.forward, out hit, _distance))
        {
            Debug.Log("Ћуч еесть ");
            var outline = hit.collider.gameObject.GetComponent<Outline>();
            if (outline != null)
            {
                Debug.Log("Ћуч не ноль ");
                _cuerrentOutline = hit.collider.gameObject.GetComponent<Outline>();
                _cuerrentOutline.OutlineMode = Outline.Mode.OutlineVisible;
            }
            else if(_cuerrentOutline != null)
            {
                Debug.Log("Ћуч ноль ");
                _cuerrentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                _cuerrentOutline = null;
            }
        }
    }

}
