using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Awake()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }

    public void HandleDeath()
    {
        SceneLoader.isPaused = true;
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
