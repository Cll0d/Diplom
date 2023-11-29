using UnityEngine;
[CreateAssetMenu(fileName ="New DetailData", menuName = "DetailData", order = 51)]
public class SODetailsData : ScriptableObject
{
    [SerializeField] private string _nameDetail;
    [SerializeField] private string _description;
    [SerializeField] private GameObject _prefab;


    public string NameDetail
    {
        get
        {
            return _nameDetail;
        }
    }

    public string Description
    {
        get
        {
            return _description;
        }
    }
}
