using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class countdown : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText2;
    private float startTime;
    public bool isFinished;
    string minutes;
    string seconds;
    string milliseconds;
    bool iscoundown = true;
    public GameObject UItamdung;

    public TextMeshProUGUI cdtxt;
    int countdownValue=3;
    IEnumerator StartCountdown()
    {
        float timer = 0f;
    float countdownInterval = 1f;
    Time.timeScale = 0f;
        while (countdownValue >= 0)
        {
            timer += Time.unscaledDeltaTime; 

            if (timer >= countdownInterval)
            {
                countdownValue--;
                timer = 0f;
                Debug.Log(countdownValue);
            }

            yield return null;
        }
        cdtxt.text = "GO" ;
        Time.timeScale = 1f;
    }

    void Start()
    {
        
        StartCoroutine(StartCountdown());
        isFinished = false;
        startTime = Time.time;

    }
    void Update()
    {
       cdtxt.text="" + countdownValue;
        if (countdownValue < 0)
        {
            cdtxt.text = null;
            iscoundown= false;
        }

        if (!isFinished)
        {
            // Tính thời gian đã trôi qua từ lúc bắt đầu
            float currentTime = Time.time - startTime;
            minutes = Mathf.Floor(currentTime / 60).ToString("00");
            seconds = Mathf.Floor(currentTime % 60).ToString("00");
            milliseconds = Mathf.Floor((currentTime * 1000) % 1000).ToString("000");
            // Chuyển đổi thời gian thành dạng chuỗi để hiển thị
           
        } 

            // Hiển thị thời gian trên giao diện người dùng
            timerText.text = minutes + ":" + seconds + ":" + milliseconds;

        timerText2.text ="Time Race: " + timerText.text;
        if (Input.GetKeyDown(KeyCode.Escape) && !iscoundown)
        {
            
            if (!UItamdung.activeSelf)
            {
                Time.timeScale = 0; 
                UItamdung.SetActive(true);
            }
            
            else
            {
                Time.timeScale = 1;
                UItamdung.SetActive(false);
            }
        }


    } 
    public void Finish()
        {
           
            isFinished = true;
        RecordTime();
           
        }
    public void RecordTime()
    {
        
        float lapTime = Time.time - startTime;
        string Map = PlayerPrefs.GetString("MapSelect", "");


        if (Map == "map1")
        {
            float bestTimeMap1 = PlayerPrefs.GetFloat("bestTimeMap1", 999999);
            if (lapTime < bestTimeMap1)
            {
                bestTimeMap1 = lapTime;
                PlayerPrefs.SetFloat("bestTimeMap1", bestTimeMap1);

            }
        }
        else if (Map == "map2")
        {
            float bestTimeMap2 = PlayerPrefs.GetFloat("bestTimeMap2", 999999);
            if (lapTime < bestTimeMap2)
            {
                bestTimeMap2 = lapTime;
                PlayerPrefs.SetFloat("bestTimeMap2", bestTimeMap2);

            }
        }
        else if (Map == "map3")
        {
            float bestTimeMap3 = PlayerPrefs.GetFloat("bestTimeMap3", 999999);
            if (lapTime < bestTimeMap3)
            {
                bestTimeMap3 = lapTime;
                PlayerPrefs.SetFloat("bestTimeMap3", bestTimeMap3);

            }
        }
        else if (Map == "map4")
        {
            float bestTimeMap4 = PlayerPrefs.GetFloat("bestTimeMap4", 999999);
            if (lapTime < bestTimeMap4)
            {
                bestTimeMap4 = lapTime;
                PlayerPrefs.SetFloat("bestTimeMap4", bestTimeMap4);

            }
        }

    }

}
