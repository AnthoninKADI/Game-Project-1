using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Main_menu : MonoBehaviour
{

    public string levelToLoad;
    public GameObject settingsWindow;
    public GameObject settingsFirstButton, settingsClosedButton;

    public GameObject missionBriefing;

    public void PressStart()
    {
        missionBriefing.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);

    }

    public void CloseSettingsWindow()
    {
        if (settingsWindow.activeInHierarchy == true)
        {
            settingsWindow.SetActive(false);
            EventSystem.current.SetSelectedGameObject(settingsClosedButton);
        }
        else return;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}