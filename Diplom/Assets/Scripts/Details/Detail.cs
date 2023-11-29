using UnityEngine;

public class Detail : MonoBehaviour
{
    [SerializeField] private SODetailsData _detailData;

    public SODetailsData DetailData
    {
        get { return _detailData; }
    }
}

