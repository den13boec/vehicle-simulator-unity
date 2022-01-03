using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RVP;
using UnityEngine.SceneManagement;

public class TrackComplete : MonoBehaviour
{
   public GameObject TrackCompleteTrig;
   public GameObject MinuteDisplay;
   public GameObject SecondDisplay;
   public GameObject MiliDisplay;
   public GameObject CarControls;
   public GameObject EngineTurnOff;
   public GameObject TrackTimeManagerToOff;
   public GameObject SavedTimeForTrack;

   // название файла сохранения чистого времени для Unity
   public string SaveNameRawTime;
   
   // переменная для сохранения чистого времени
   public float RawTimeSaved;
   void OnTriggerEnter()
   {
      // название файлов сохранения времени для Unity
      string SaveNameMinTime = SavedTimeForTrack.GetComponent<LoadTrackTime>().SaveNameMin;
      string SaveNameMiliTime = SavedTimeForTrack.GetComponent<LoadTrackTime>().SaveNameMili;
      string SaveNameSecTime = SavedTimeForTrack.GetComponent<LoadTrackTime>().SaveNameSec;

      // получаем сохранённое без округлений время лучшего заезда
      RawTimeSaved = PlayerPrefs.GetFloat(SaveNameRawTime);
      // проверка с сохранённым временем и первый ли это заезд
      // то есть равняется ли сохранённое время нулю
      if (TrackTimeManager.RawTimeLevel <= RawTimeSaved || RawTimeSaved == 0)
      {
         // если это новый рекорд, то выводим его в лучшее время и сохраняем
         if (TrackTimeManager.SecondCount <= 9)
         {
            SecondDisplay.GetComponent<Text>().text = "0" + TrackTimeManager.SecondCount + ".";
         }
         else
         {
            SecondDisplay.GetComponent<Text>().text = "" + TrackTimeManager.SecondCount + ".";
         }

         if (TrackTimeManager.MinuteCount <= 9)
         {
            MinuteDisplay.GetComponent<Text>().text = "0" + TrackTimeManager.MinuteCount + ":";
         }
         else
         {
            MinuteDisplay.GetComponent<Text>().text = "" + TrackTimeManager.MinuteCount + ":";
         }

         MiliDisplay.GetComponent<Text>().text = "" + Mathf.Round(TrackTimeManager.MiliCount);

         PlayerPrefs.SetInt(SaveNameMinTime, TrackTimeManager.MinuteCount);
         PlayerPrefs.SetInt(SaveNameSecTime, TrackTimeManager.SecondCount);
         PlayerPrefs.SetFloat(SaveNameMiliTime, TrackTimeManager.MiliCount);
         PlayerPrefs.SetFloat(SaveNameRawTime, TrackTimeManager.RawTimeLevel);
         PlayerPrefs.Save();
      }
      
      // при финише убираем урон по машине, отбираем управление и выключаем двигатель
      CarControls.GetComponent<VehicleDamage>().enabled=false;
      CarControls.GetComponent<BasicInput>().enabled=false;
      EngineTurnOff.GetComponent<GasMotor>().ignition = false;
      
      // обнуляем параметры
      TrackTimeManager.MinuteCount = 0;
      TrackTimeManager.SecondCount = 0;
      TrackTimeManager.MiliCount = 0;
      TrackTimeManager.RawTimeLevel = 0;

      // также отключаем таймер на прохождение трассы
      TrackTimeManagerToOff.SetActive(false);
      
      // отключаем колайдер тригера на завершение трассы, чтобы не было повторных срабатываний
      TrackCompleteTrig.GetComponent<BoxCollider>().enabled = false;
      
      // вызываем корутин чтобы подождать 2 секунды после окончания заезда
      // и вернуться в меню выбора заездов
      StartCoroutine(CountExit());
      
      IEnumerator CountExit()
      {
         yield return new WaitForSeconds(3);
         SceneManager.LoadScene(1);
      }
   }
}
