using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skilldisplay : MonoBehaviour
{
    public Skill skill;

    public Image artskill;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (skill == null)
        {
            artskill.sprite = null;
        }
        else
        {
            artskill.sprite = skill.getanhskill();
        }
    }
}
