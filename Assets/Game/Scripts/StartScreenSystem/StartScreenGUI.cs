using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreenGUI : MonoBehaviour
{
    [SerializeField] Button hostButton;
    [SerializeField] Button clientButton;

    [Header("Unity Events")]
    public UnityEvent OnHostButtonPressed;
    public UnityEvent OnClientButtonPressed;

    public void Start()
    {
        hostButton.onClick.AddListener(() => OnHostButtonPressed.Invoke());
        clientButton.onClick.AddListener(() => OnClientButtonPressed.Invoke());
    }

}