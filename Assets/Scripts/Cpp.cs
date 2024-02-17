using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cpplayer : MonoBehaviour
{
    public GameObject[] checkpoints;
    public int m = -1;
    public GameObject UIthang;
    public GameObject UIbutton;
    public GameObject UIthua;
    public static Cpplayer Instance;
    public TopDownCarController carController;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       
    }
    void Start()
    {
        carController = GetComponent<TopDownCarController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (m == checkpoints.Length -1 && !UIthua.activeSelf)
        {
            
            carController.stop();
           UIthang.SetActive(true);
           UIbutton.SetActive(true);
            
        }    
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (collision.gameObject == checkpoints[i] && m == i-1)
                {
                    m = i;
               
                    break;
                }
            }
        
    }
   
}
