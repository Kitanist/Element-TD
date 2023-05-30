using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static bool gameIsPaused,gameIsStarted = false;

    public GameObject PauseMenu;

    public GameObject SettingsMenu;

    public GameObject Panel;

    public AudioSource Theme;

    public GameObject PauseSettingsMenu;

    public MainMenuCamController cam;

    public Slider music;

    public CanvasGroup DArkness;

    [Header("Kamera Hareketi")]
    public Vector3 settingsOpenPos;
    public Vector3 normalPos;
    public Vector3 startingPos;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsStarted)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadGame() 
    {
        gameIsStarted = true;
        cam.SetCamPos(startingPos);
        DArkness.LeanAlpha(1, 1);
        StartCoroutine(LoadGameWaiter());

    }
    IEnumerator LoadGameWaiter()
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowSettings() 
    {
      
        cam.SetCamPos(settingsOpenPos);
        StartCoroutine(ShowSettingsEnum());
    }
    IEnumerator ShowSettingsEnum()
    {
        yield return new WaitForSeconds(1.2f);
        SettingsMenu.SetActive(true);
    }
    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }

    public void SetFullscreen(bool isFull)
    {
        
        Screen.fullScreen = isFull;
    }

    public void SetMusic()
    {

        Theme.volume = music.value;

    }
    public void PauseSettings()
    {
        PauseMenu.SetActive(false);
        PauseSettingsMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void BeNormal()
    {
        SettingsMenu.SetActive(false);
        cam.SetCamPos(normalPos);

    }
    public void EndGame()
    {
        Application.Quit();
    }

}
