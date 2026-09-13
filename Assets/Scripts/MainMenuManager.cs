using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelSelectPanel;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject soundManager;
    public void PlayGame() {
        SceneManager.LoadScene(1);
        EnableUI();
        EnableSoundManager(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }

    public void OpenLevelSelect()
    {
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    private void EnableSoundManager(bool enable)
    {
        if (soundManager != null)
        {
            soundManager.SetActive(enable);
        }
    }

    public void CloseLevelSelect()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        EnableUI();
    }

    private void EnableUI()
    {
        UI.SetActive(true);
    }

}
