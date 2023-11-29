using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static Action<string> OnLooked;
    public static Action OnNoLooked;
    public static Action OnLookedPanel;

}
