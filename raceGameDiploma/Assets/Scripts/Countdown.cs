using System.Collections;
using System.Collections.Generic;
using RVP;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject CountDown;
    public GameObject TrackTimer;
    public GameObject CarControls;
    
    void Start()
    {
        // запускаем корутин
        StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
        // отбираем управление машиной на время отсчёта
        CarControls.GetComponent<BasicInput>().enabled = false;
        CarControls.GetComponent<VehicleDebug>().enabled = false;
        // ждём полсекунды
        yield return new WaitForSeconds(0.5f);
        // прогоняем анимацию отсчёта
        CountDown.GetComponent<Text>().text = "3";
        CountDown.SetActive(true);
        // ждём секунду
        yield return new WaitForSeconds(1);
        // делаем элемент HUD не активным
        CountDown.SetActive(false);
        // заменяем текст на следующую цифру
        CountDown.GetComponent<Text>().text = "2";
        // снова делаем HUD элемент активным, чтобы проигралась анимация
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "1";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        // отсчёт заканчивается
        CountDown.SetActive(false);
        // включается игровой объект к которому прикреплён скрипт на отсчёт времени заезда
        TrackTimer.SetActive(true);
        
        // даём обратно управление над машиной
        CarControls.GetComponent<BasicInput>().enabled = true;
        CarControls.GetComponent<VehicleDebug>().enabled = true;
        
        // обнуляем время, так как сцена могла быть перезапущена
        // и время уже ненулевое
        TrackTimeManager.MinuteCount = 0;
        TrackTimeManager.SecondCount = 0;
        TrackTimeManager.MiliCount = 0;
        TrackTimeManager.RawTimeLevel = 0;
    }
}