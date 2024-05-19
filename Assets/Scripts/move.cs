using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject vitri;
    public float speedmove = 2f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, transform.position + tr?, 100 * speedmove * Time.deltaTime);

            
        
    }
    
}
