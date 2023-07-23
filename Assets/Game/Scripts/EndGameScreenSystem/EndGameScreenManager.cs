using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScreenManager : MonoBehaviour
{
    [SerializeField] EndGameScreenGUI endGameScreenGUI;

    public void Start()
    {
        endGameScreenGUI.OnRestartPressed.AddListener(() =>
        {
            RestartScene();
        });
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowScreen()
    {
        endGameScreenGUI.gameObject.SetActive(true);
    }

    public void HideScreen()
    {
        endGameScreenGUI.gameObject.SetActive(false);
    }
}
