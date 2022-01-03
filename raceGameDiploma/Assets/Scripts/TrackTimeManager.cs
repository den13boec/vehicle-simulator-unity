using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MiliCount;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MiliBox;

    // эта переменная нужна для сохранения чистого без округления времени заезда
    public static float RawTimeLevel;
    
    void Update()
    {
        // прибавляем один фрэйм времени по Unity, умножаем на 10 чтобы были милисекунды, изначально секунды
        MiliCount += Time.deltaTime * 10;
        // прибавляем один фрэйм времени по Unity
        RawTimeLevel += Time.deltaTime;
        
        // если больше 10 миллисекунд, то переводим в 1 секунду и сбрасываем миллисекунды
        if (MiliCount >= 9)
        {
            MiliCount = 0;
            SecondCount += 1;
        }
        
        // округляем милисекунды
        MiliBox.GetComponent<Text>().text = "" + Mathf.Round(MiliCount);
        
        // аналогично милисекундам, если 60 секунд, то переводим их в 1 минуту и сбрасываем секунды
        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }
        
        // условности вывода в текстовые поля: если секунды\минуты меньше или равны 9,
        // то добавляем 0, если нет то не добавляем
        if (SecondCount <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
        }
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
        }
        
        if (MinuteCount <= 9)
        {
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
        }
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
        }
    }
}
