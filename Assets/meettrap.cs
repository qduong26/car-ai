using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class meettrap : MonoBehaviour
{
    public Vector3 position;
    public Vector3 trapposition;
    public bool isbeartrap=false;
    Cpplayer cpp;
    TopDownCarController topDownCarController;
    float maxSpeedoriginal;
    void Start()
    {
        topDownCarController = GetComponent<TopDownCarController>();
        maxSpeedoriginal = topDownCarController.maxSpeed;
        cpp = GetComponent<Cpplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isbeartrap) { 
         beartrap();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "40")
        {
           
            topDownCarController.maxSpeed = 7f;

        }
        if (collision.gameObject.tag == "beartrap")
        {
            position = transform.position;
            trapposition = collision.transform.position;    
            isbeartrap = true;
            collision.transform.position = position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "40")
        {

            topDownCarController.maxSpeed = maxSpeedoriginal;

        }
    }
    IEnumerator beartrap()
    {
        transform.position = trapposition;
        yield return new WaitForSeconds(1f);
        isbeartrap = false;



    }

}
