using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayxe : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dayxe")
        {
            if (gameObject.tag == "Player")
            {
                rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
            }
            else if (gameObject.tag == "car")
            {
                rb.AddForce(transform.up * 1f, ForceMode2D.Impulse);
            }
        }
    }

}
