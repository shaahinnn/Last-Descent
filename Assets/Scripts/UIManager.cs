using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPage;
    [SerializeField] GameObject controlPage;
    [SerializeField] GameObject musicOnButton;
    [SerializeField] GameObject musicOffButton;

    [SerializeField] AudioSource musicAudio;
    bool isOpen = false;
    private void Start()
    {
        musicAudio.Play();
        settingsPage.SetActive(false);
        controlPage.SetActive(false);
    }
    public void OpenSettingsPage()
    {
        if (isOpen == true)
        {
            return;
        }
        settingsPage.SetActive(true);
        isOpen = true;
    }
    public void CloseSettingsPage()
    {
        settingsPage.SetActive(false);
        isOpen = false;
    }
    public void OpenControlPage()
    {
        controlPage.SetActive(true);
        settingsPage.SetActive(false);
        isOpen = true;
    }
    public void CloseControlPage()
    {
        controlPage.SetActive(false);
        settingsPage.SetActive(true);
        isOpen = false; 
    }
    public bool BugFix()
    {
        return isOpen;
    }
    public void MusicOn()
    {
        musicOnButton.SetActive(false);
        musicOffButton.SetActive(true);
        musicAudio.Stop();
    }
    public void MusicOff()
    {
        musicOnButton.SetActive(true);
        musicOffButton.SetActive(false);
        musicAudio.Play();
    }

}


