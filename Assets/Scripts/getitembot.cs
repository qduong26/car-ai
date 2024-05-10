using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getitembot : MonoBehaviour
{
    // Start is called before the first frame update
    ItemHandler itemhandler;
    public Skill[] skill;

    public GameObject fire;
    public GameObject beartrap;
    public GameObject mingo;
    // Update is called once per frame
    private void Awake()
    {
        
        itemhandler = gameObject.GetComponent<ItemHandler>();
    }
    void Update()
    {
        
        
    }
    void min()
    {
        itemhandler.min(mingo);
    }
    void shield()
    {
        itemhandler.Shield();
    }
    void star()
    {
        itemhandler.star();
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
    void fireball()
    {
        itemhandler.dan(fire);
    }
    void beartrapspawn()
    {
        itemhandler.min(beartrap);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            Destroy(collision.gameObject);
            System.Action[] functions = { small, big, through, speedup,min,shield,star, fireball , beartrapspawn };
            int randomIndex = Random.Range(0, functions.Length);
            System.Action selectedFunction = functions[randomIndex];


            selectedFunction();




        }
    }
}
