using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class countdown : MonoBehaviour
{
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
        
    }
    void Update()
    {
       cdtxt.text="" + countdownValue;
        if (countdownValue < 0)
        {
            cdtxt.text = null;
        }
    }
}
