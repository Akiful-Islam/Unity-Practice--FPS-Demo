using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas menuCanvas;
    [SerializeField] Canvas statsCanvas;
    [SerializeField] Canvas reticleCanvas;
    [SerializeField] Camera menuCamera, gameplayCamera;

    public static bool isPaused;

    private void Awake()
    {
        StartMenu();
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

    private void StartMenu()
    {
        menuCanvas.gameObject.SetActive(true);
        menuCamera.enabled = true;
        gameplayCamera.enabled = false;
        Time.timeScale = 0;
        isPaused = true;
        menuCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        statsCanvas.gameObject.SetActive(false);
        reticleCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        isPaused = false;
        gameplayCamera.enabled = true;
        menuCamera.enabled = false;
        menuCamera.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(false);
        reticleCanvas.gameObject.SetActive(true);
        statsCanvas.gameObject.SetActive(true);
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
    }


    public void Restart()
    {
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        isPaused = true;
        ToggleCanvases(isPaused);
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        ToggleCanvases(isPaused);
        FindObjectOfType<WeaponSwitcher>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void ToggleCanvases(bool paused)
    {
        pauseCanvas.gameObject.SetActive(paused);
        statsCanvas.gameObject.SetActive(!paused);
        reticleCanvas.gameObject.SetActive(!paused);
    }
}
