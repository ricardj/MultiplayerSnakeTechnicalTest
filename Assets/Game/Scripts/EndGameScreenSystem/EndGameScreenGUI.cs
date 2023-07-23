using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndGameScreenGUI : MonoBehaviour
{
    [SerializeField] Button restartButton;

    [Header("Unity Events")]
    public UnityEvent OnRestartPressed;

    public void Start()
    {
        restartButton.onClick.AddListener(OnRestartPressed.Invoke);
    }

}
