using UnityEngine;

public class PauseUi : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isGamePaused = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            if(isGamePaused)
                ResumeGame();
            else
                PauseGame();
    }

    private void PauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
    }
}
