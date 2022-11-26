using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] Canvas completedCanvas;
    [SerializeField] private int enemiesLeft;


    private void Awake()
    {
        completedCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        CountEnemies();
    }

    private void CountEnemies()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft < 1)
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        completedCanvas.gameObject.SetActive(true);
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        SceneLoader.isPaused = true;
    }
}
