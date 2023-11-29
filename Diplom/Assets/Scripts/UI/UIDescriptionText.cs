using TMPro;
using UnityEngine;

public class UIDescriptionText : MonoBehaviour
{
    [SerializeField] private TMP_Text _descriptionDetail;
    [SerializeField] private GameObject _panel;



    private void OnEnable()
    {
        EventBus.OnLooked += ChangedText;
        EventBus.OnNoLooked += HiddenPanel;
        EventBus.OnLookedPanel += ShowPanel;
    }

    private void OnDisable()
    {
        EventBus.OnLooked -= ChangedText;
        EventBus.OnNoLooked -= HiddenPanel;
        EventBus.OnLookedPanel -= ShowPanel;
    }

    private void ChangedText(string text)
    {
        _descriptionDetail.text = text;
        _panel.SetActive(true);
    }

    private void HiddenPanel()
    {
        _panel.SetActive(false);
    }
    private void ShowPanel()
    {
        _panel.SetActive(true);
    }

}
