using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class RayOutlIne : MonoBehaviour
{
    [SerializeField]private Transform transformCamera;
    [SerializeField] private float _distance = 8;
    [SerializeField] private TMP_Text _textMeshPro;
    private Outline _cuerrentOutline;


    private void Start()
    {
        _textMeshPro.alpha = 0;
    }
    private void Update()
    {
        OutlineObject();
    }
    void OutlineObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(transformCamera.transform.position, transformCamera.transform.forward, out hit, _distance))
        {
            var outline = hit.collider.gameObject.GetComponent<Outline>();
            var detail = hit.collider.gameObject.GetComponent<Item>();
            if (outline != null || detail != null)
            {
                _textMeshPro.alpha = 175;
                _textMeshPro.text = detail.NameDetail;
                _cuerrentOutline = hit.collider.gameObject.GetComponent<Outline>();
                _cuerrentOutline.OutlineMode = Outline.Mode.OutlineVisible;
            }
            else if(_cuerrentOutline != null)
            {
                _cuerrentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                _cuerrentOutline = null;
                // _textMeshPro.enabled = false;
                _textMeshPro.alpha = 0;
            }
        }
    }

}
