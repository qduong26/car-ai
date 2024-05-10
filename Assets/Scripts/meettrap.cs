using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class meettrap : MonoBehaviour
{
    Rigidbody2D rb;
    public bool trungmin=false;
    ItemHandler itemHandler;
    public GameObject no;
    TopDownCarController topDownCarController;
    Vector3 stopposition;
    float maxSpeedoriginal;
    bool istrap = false;
    void Start()
    {
        itemHandler = gameObject.GetComponent<ItemHandler>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        topDownCarController = gameObject.GetComponent<TopDownCarController>();
        maxSpeedoriginal = topDownCarController.maxSpeed;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (istrap)
        {
            
            gameObject.transform.position = stopposition;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "40")
        {
           
            topDownCarController.maxSpeed = 7f;

        }
        if (collision.gameObject.tag == "min" )
        {

            Destroy(collision.gameObject);

            Instantiate(no, collision.transform.position, Quaternion.identity);
           
            if ((itemHandler.baove == false) && (itemHandler.vodich == false)) {
                
                Vector2 hitDirection = (transform.position - collision.transform.position).normalized;

                rb.AddForce(hitDirection * 5f, ForceMode2D.Impulse);

                StartCoroutine(ditrungmin()); }



        }
        if (collision.gameObject.tag == "fire")
        {
            tenlua firescript = collision.gameObject.GetComponent<tenlua>();
            if (firescript.target == gameObject)
            {
                Destroy(collision.gameObject);

                Instantiate(no, collision.transform.position, Quaternion.identity);

                if ((itemHandler.baove == false) && (itemHandler.vodich == false))
                {

                    Vector2 hitDirection = (transform.position - collision.transform.position).normalized;

                    rb.AddForce(hitDirection * 5f, ForceMode2D.Impulse);

                    StartCoroutine(ditrungmin());
                }
            }


        }
        if (collision.gameObject.tag == "beartrap")
        {

            Destroy(collision.gameObject);
            if ((itemHandler.baove == false) && (itemHandler.vodich == false))
            {

                Debug.Log(itemHandler.baove);
                stopposition = gameObject.transform.position;

                StartCoroutine(meetbeartrap());
            }



        }


    }
    IEnumerator meetbeartrap()
    {
        istrap = true;
        yield return new WaitForSeconds(2f);

        istrap = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "40")
        {

            topDownCarController.maxSpeed = maxSpeedoriginal;

        }
    }

    IEnumerator ditrungmin()
    {
        trungmin = true;
        yield return new WaitForSeconds(1.5f);
       
        trungmin = false;
    }
}
