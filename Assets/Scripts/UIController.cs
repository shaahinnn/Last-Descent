using UnityEngine;

public class UIController : MonoBehaviour
{
   
    GameSession gameSession;
    CollisionHandler collisionHandler;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject musicOnButton;
    [SerializeField] GameObject musicOffButton;
    bool isPause;

    void Start()
    {
        gameSession = FindFirstObjectByType<GameSession>();
        collisionHandler = FindFirstObjectByType<CollisionHandler>();
        pauseMenu.SetActive(false);
        winPanel.SetActive(false);
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPauseMenu()
    {
        if(collisionHandler.Win() == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
        }
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
    public void RestartGame()
    {
        gameSession.RestartScene();
        Time.timeScale = 1f;
    }
    public void LoadHomeScene()
    {
        gameSession.LoadHomeScene();
        Time.timeScale = 1f;
    }
    public void EnableWinPanaL()
    {
        winPanel.SetActive(true);
    }
    public bool PauseBug()
    {
        return isPause;
    }
    public void MusicOn()
    {
        musicOnButton.SetActive(false);
        musicOffButton.SetActive(true);
    
    }
    public void MusicOff()
    {
        musicOnButton.SetActive(true);
        musicOffButton.SetActive(false);
 
    }

}
