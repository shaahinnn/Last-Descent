
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int currentScene;
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem smokeParticles;
    [SerializeField] GameObject[] healthBar;


    AudioSource gameAudio;
    UIController uiControl;

    bool isControllable = true;
    bool isWin = false;
    int health = 3;



    private void Start()
    {
 
        GetComponent<Movement>().enabled = true;
        uiControl = FindFirstObjectByType<UIController>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        gameAudio = GetComponent<AudioSource>();
        if (health == 3)
        {
            healthBar[0].gameObject.SetActive(true);
            healthBar[1].gameObject.SetActive(false);
            healthBar[2].gameObject.SetActive(false);
            healthBar[3].gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        RespondToDebugKeys();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isControllable)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                Debug.Log("Finish");
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            case "Win":
                Debug.Log("Win");
                isControllable = false;
                uiControl.EnableWinPanaL();
                successParticles.Play();
                gameAudio.Stop();
                Debug.Log("Success");
                gameAudio.PlayOneShot(successAudio);
                GetComponent<Movement>().enabled = false;
                isWin = true;
                break;
            default:
                if (collision.gameObject)
                {
                   HealthManager();
                }
                break;
        }
       
    }
    void HealthManager()
    {
        health--;
        Debug.Log("Health: " + health);
        if (health == 2)
        {
            healthBar[1].gameObject.SetActive(true);
            healthBar[0].gameObject.SetActive(false);
            healthBar[2].gameObject.SetActive(false);
            healthBar[3].gameObject.SetActive(false);
       
        }
        else if (health == 1)
        {
            healthBar[2].gameObject.SetActive(true);
            healthBar[1].gameObject.SetActive(false);
            healthBar[0].gameObject.SetActive(false);
            healthBar[3].gameObject.SetActive(false);
       
        }
        else if (health <= 0)
        {
            healthBar[3].gameObject.SetActive(true);
            healthBar[2].gameObject.SetActive(false);
            healthBar[1].gameObject.SetActive(false);
            healthBar[0].gameObject.SetActive(false);
            StartCrashSequence();
            Invoke("EnableSmoke", 0.25f);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
    }
    void LoadNextScene()
    {
        int nextScene = currentScene + 1;
        if(nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
    void StartCrashSequence()
    {
        isControllable = false;
        crashParticles.Play();
        gameAudio.Stop();
        Debug.Log("Crash");
        if(!gameAudio.isPlaying)
        gameAudio.PlayOneShot(crashAudio);
        Invoke("ReloadScene", levelLoadDelay);
        GetComponent<Movement>().enabled = false;
    }
    void StartSuccessSequence()
    {
        isControllable = false;
        successParticles.Play();
        gameAudio.Stop();
        Debug.Log("Success");
        gameAudio.PlayOneShot(successAudio);
        Invoke("LoadNextScene", levelLoadDelay);
        GetComponent<Movement>().enabled = false;
    }
    void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextScene();
        }
        if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            isControllable = !isControllable;
        }
        
    }
    public bool Win()
    {
        return isWin;
    }
    public void EnableSmoke()
    {
        smokeParticles.Play();
    }
}
