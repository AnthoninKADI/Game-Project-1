using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        playerController.gameIsPaused = false;

    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}