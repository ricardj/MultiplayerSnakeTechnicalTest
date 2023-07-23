using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScreenManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] StartScreenGUI startScreenGUI;

    [Header("Unity Events")]
    public UnityEvent OnHostButtonPressed;
    public UnityEvent OnClientButtonPressed;

    public void Start()
    {
        startScreenGUI.OnClientButtonPressed.AddListener(OnClientButtonPressed.Invoke);
        startScreenGUI.OnHostButtonPressed.AddListener(OnHostButtonPressed.Invoke);
    }

    public void HideScreen()
    {
        startScreenGUI.gameObject.SetActive(false);
    }
}
