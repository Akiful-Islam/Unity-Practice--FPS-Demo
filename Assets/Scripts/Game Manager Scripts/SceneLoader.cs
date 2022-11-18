using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas menuCanvas;

    public static bool isPaused;

    private void Awake()
    {
        Time.timeScale = 0;
        isPaused = true;
        menuCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        menuCanvas.gameObject.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        isPaused = true;
        pauseCanvas.gameObject.SetActive(true);
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        menuCanvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(false);
        FindObjectOfType<WeaponSwitcher>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
