using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getitem : MonoBehaviour
{
    // Start is called before the first frame update
    ItemHandler itemhandler;
    public Skill[] skill;
    public GameObject selectskill;
    skilldisplay skilldisplay;
    public GameObject mingo;
    public GameObject fire;
    public GameObject beartrap;
    // Update is called once per frame
    private void Awake()
    {
        skilldisplay = selectskill.GetComponent<skilldisplay>();
        itemhandler = gameObject.GetComponent<ItemHandler>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skilldisplay.skill.name == "skill1")
            {
                big();
            }
            else if(skilldisplay.skill.name == "skill2" )
            {
                through();
            }
            else if (skilldisplay.skill.name == "skill3")
            {
                small();
            }
            else if (skilldisplay.skill.name == "skill4")
            {
                speedup();
            }
            else if (skilldisplay.skill.name == "skill5")
            {
                min();
            }
            else if (skilldisplay.skill.name == "skill6")
            {
                shield();
            }
            else if (skilldisplay.skill.name == "skill7")
            {
                star();
            }
            else if (skilldisplay.skill.name == "skill8")
            {
                fireball();
            }
            else if (skilldisplay.skill.name == "skill9")
            {
                beartrapspawn();
            }
            skilldisplay.skill = skill[0];
        }
       
    }
    void fireball()
    {
        itemhandler.dan(fire);
    }
    void beartrapspawn()
    {
        itemhandler.min(beartrap);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "box") {
            Destroy(collision.gameObject);
            
            int randomIndex = Random.Range(1, skill.Length);
            skilldisplay.skill = skill[randomIndex];

            
           

        }
    }
}
