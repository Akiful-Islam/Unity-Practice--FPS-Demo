using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] Canvas completedCanvas;
    private GameObject[] enemies;
    private int enemiesLeft;


    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        completedCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        CountEnemies();
    }

    private void CountEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyHealth>().IsDead)
            {
                enemiesLeft--;
            }
        }
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
