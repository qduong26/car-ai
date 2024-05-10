using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Skill")]
public class Skill : ScriptableObject
{
    public string nameskill;
    public Sprite anhskill;

    public Sprite getanhskill()
    {
        return anhskill;
    }
}
