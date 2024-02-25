using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getitem : MonoBehaviour
{
    // Start is called before the first frame update
    ItemHandler itemhandler;
    

    // Update is called once per frame
    void Update()
    {
        itemhandler = gameObject.GetComponent<ItemHandler>();
    }
    void small()
    {
        itemhandler.small();
    }

    void big()
    {
        itemhandler.big();
    }

    void through()
    {
        itemhandler.through();
    }
    void speedup()
    {
        itemhandler.speedup();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "box") {
            Destroy(collision.gameObject);
            System.Action[] functions = { small, big, through,speedup };
            int randomIndex = Random.Range(0, functions.Length);
            System.Action selectedFunction = functions[randomIndex];

            
            selectedFunction();
            

        }
    }
}
