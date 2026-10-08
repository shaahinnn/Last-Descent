using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    UIManager uIManager;
    int currentSceneIndex;
    int nextSceneIndex;
    private void Start()
    {
        uIManager = FindFirstObjectByType<UIManager>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
    }
    public void NextScene()
    {
        if(uIManager.BugFix() == true)
        {
            return;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadHomeScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        if (uIManager.BugFix() == true)
        {
            return;
        }
        Application.Quit();
    }
}
