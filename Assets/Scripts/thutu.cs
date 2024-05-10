using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thutu : MonoBehaviour
{
    
    public GameObject thu1;
    public GameObject thu2;
    public GameObject thu3;
    public GameObject thu4;
    
   
    void Start()
    {
        
      

    }

    // Update is called once per frame
    void Update()
    {
        
        thu1.transform.position = Cpplayer.OrderGameobject[0].transform.position;
        thu2.transform.position = Cpplayer.OrderGameobject[1].transform.position;
        thu3.transform.position = Cpplayer.OrderGameobject[2].transform.position;
        thu4.transform.position = Cpplayer.OrderGameobject[3].transform.position;

    }

    

}
