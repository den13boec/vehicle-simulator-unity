using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOptions : MonoBehaviour
{
    // загрузить меню выбора уровня
    public void TrackSelect()
    {
        SceneManager.LoadScene(1);
    }
    
    // загрузить уровень с городом, заезд на время
    public void TrackCityDay()
    {
        SceneManager.LoadScene(2);
    }
    
    // загрузить уровень с городом, свободный заезд
    public void TrackCityFree()
    {
        SceneManager.LoadScene(4);
    }
    
    // загрузить лесной уровень
    public void TrackForest()
    {
        SceneManager.LoadScene(3);
    }
    
    // загрузить основное меню
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    // стереть все сохранения Unity
    public void ClearAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }
    
    // выйти из игры
    public void GameExit()
    {
        Application.Quit();
    }
    
    // перейти к информацию об управлении
    public void ControlInfo()
    {
        SceneManager.LoadScene(5);
    }
    
}
