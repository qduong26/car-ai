using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class showbesttime : MonoBehaviour
{
    public TextMeshProUGUI btm1;
    public TextMeshProUGUI btm2;
    public    TextMeshProUGUI btm3;
    public TextMeshProUGUI btm4;
    // Start is called before the first frame update
    void Start()
    {
        float bestTimeMap1 = PlayerPrefs.GetFloat("bestTimeMap1", 0);
        float bestTimeMap2 = PlayerPrefs.GetFloat("bestTimeMap2", 0);
        float bestTimeMap3 = PlayerPrefs.GetFloat("bestTimeMap3", 0);
        float bestTimeMap4 = PlayerPrefs.GetFloat("bestTimeMap4", 0);
        string minutes1 = Mathf.Floor(bestTimeMap1 / 60).ToString("00");
        string seconds1 = Mathf.Floor(bestTimeMap1 % 60).ToString("00");
        string milliseconds1 = Mathf.Floor((bestTimeMap1 * 1000) % 1000).ToString("000");
        btm1.text = minutes1 + ":" + seconds1 + ":" + milliseconds1;

        string minutes2 = Mathf.Floor(bestTimeMap2 / 60).ToString("00");
        string seconds2 = Mathf.Floor(bestTimeMap2 % 60).ToString("00");
        string milliseconds2 = Mathf.Floor((bestTimeMap2 * 1000) % 1000).ToString("000");
        btm2.text = minutes2 + ":" + seconds2 + ":" + milliseconds2;

        string minutes3 = Mathf.Floor(bestTimeMap3 / 60).ToString("00");
        string seconds3 = Mathf.Floor(bestTimeMap3 % 60).ToString("00");
        string milliseconds3 = Mathf.Floor((bestTimeMap3 * 1000) % 1000).ToString("000");
        btm3.text = minutes3 + ":" + seconds3 + ":" + milliseconds3;
        string minutes4 = Mathf.Floor(bestTimeMap3 / 60).ToString("00");
        string seconds4 = Mathf.Floor(bestTimeMap3 % 60).ToString("00");
        string milliseconds4 = Mathf.Floor((bestTimeMap3 * 1000) % 1000).ToString("000");
        btm4.text = minutes4 + ":" + seconds4 + ":" + milliseconds4;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
