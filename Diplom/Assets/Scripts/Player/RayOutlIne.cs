using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
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
    private Item _currentItem;


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
            var detail = hit.collider.gameObject.GetComponent<Item>();
            Outline outline = hit.collider.gameObject.GetComponent<Outline>();
            if (outline)
            {
                if (_cuerrentOutline && _cuerrentOutline != outline)
                {
                    _cuerrentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                    _cuerrentOutline.OutlineWidth = 0;
                    _textMeshPro.alpha = 0;
                }
                _cuerrentOutline = outline;
                outline.OutlineMode = Outline.Mode.OutlineVisible;
                _cuerrentOutline.OutlineWidth = 2;
                _textMeshPro.alpha = 175;
                _textMeshPro.text = detail.NameDetail;
            }
            else
            {
                if (_cuerrentOutline)
                {
                    _cuerrentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                    _cuerrentOutline.OutlineWidth = 0;
                    _cuerrentOutline = null;
                    _textMeshPro.alpha = 0;
                }

            }
        }
        else
        {
            if (_cuerrentOutline)
            {
                _cuerrentOutline.OutlineMode = Outline.Mode.OutlineHidden;
                _cuerrentOutline.OutlineWidth = 0;
                _cuerrentOutline = null;
                _textMeshPro.alpha = 0;
            }
        }

    }
}
