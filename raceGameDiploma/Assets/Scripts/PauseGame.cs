using System.Collections;
using System.Collections.Generic;
using RVP;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject mainHud;
    
    void Update()
    {
        // по кнопке останавливаем время и показываем меню паузы
        if (Input.GetButtonDown("Cancel"))
        {
            // если игра ещё не остановлена, то скрываем HUD основной и показываем меню паузы
            // ставим игру на паузу
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                mainHud.SetActive(false);
            }
            // если игра остановлена, то этой же кнопкой игра возобновляется
            else
            {
                pauseMenu.SetActive(false);
                mainHud.SetActive(true);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }
    
    // кнопка возобновить игру
    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        mainHud.SetActive(true);
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
    }
    
    // кнопка рестарта уровня
    public void RestartLevel()
    {
        pauseMenu.SetActive(false);
        mainHud.SetActive(true);
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
        // получаем номер ID сцены в которой мы сейчас находимся, чтобы сделать рестарт уровня
        int sceneCurrentID = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneCurrentID);
    }
    
    // кнопка выхода в меню
    public void QuitToMenu()
    {
        pauseMenu.SetActive(false);
        mainHud.SetActive(true);
        gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
