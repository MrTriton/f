using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsBehaviourUi : MonoBehaviour
{
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}