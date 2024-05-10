using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMap : MonoBehaviour
{
    public GameObject[] listmap;
    public GameObject[] cpmap1;
    public GameObject[] cpmap2;
    public GameObject[] cpmap3;
    public GameObject[] cpmap4;

    private void Awake()
    {
        
        for (int i = 0; i < listmap.Length; i++)
        {
            listmap[i].SetActive(false);
        }

        string Map = PlayerPrefs.GetString("MapSelect", "");


        if (Map == "map1")
        {
            listmap[0].SetActive(true);
            Cpplayer.checkpoints = cpmap1;
        }
        else if (Map == "map2")
        {
            listmap[1].SetActive(true);
            Cpplayer.checkpoints = cpmap2;
        }
        else if (Map == "map3")
        {
            listmap[2].SetActive(true);
            Cpplayer.checkpoints = cpmap3;
        }
        else if (Map == "map4")
        {
            listmap[3].SetActive(true);
            Cpplayer.checkpoints = cpmap4;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
