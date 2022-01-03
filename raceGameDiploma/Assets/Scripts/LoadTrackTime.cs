using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTrackTime : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public float MiliCount;

    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MiliDisplay;

    // названия сохранений Unity
    public string SaveNameMin;
    public string SaveNameSec;
    public string SaveNameMili;
    
    void Start()
    {
        // загрузка лучшего времени из сохранённых данных Unity (PlayerPrefs)
        // если ничего не находится, то получаем 0
        MinCount = PlayerPrefs.GetInt(SaveNameMin);
        SecCount = PlayerPrefs.GetInt(SaveNameSec);
        MiliCount = PlayerPrefs.GetFloat(SaveNameMili);
        
        // условности вывода в текстовые поля лучшего времени трассы
        if (MinCount <= 9)
        {
            MinDisplay.GetComponent<Text>().text = "0" + MinCount + ":";
        }
        else
        {
            MinDisplay.GetComponent<Text>().text = "" + MinCount + ":";
        }
      
        if (SecCount <= 9)
        {
            SecDisplay.GetComponent<Text>().text = "0" + SecCount + ".";
        }
        else
        {
            SecDisplay.GetComponent<Text>().text = "" + SecCount + ".";
        }
        // округляем миллисекунды
        MiliDisplay.GetComponent<Text>().text = "" + Mathf.Round(MiliCount);
    }
}
