using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GetChar : MonoBehaviour
{
    public Char Select;
    public Char[] Char;
    public Char[] Charbot;

    traiphai traiphai;

    public GameObject Bot1;
    public GameObject Bot2;
    public GameObject Bot3;
    traiphai traiphaibot1;
    traiphai traiphaibot2;
    traiphai traiphaibot3;

    void Awake()
    {
        
        traiphaibot1= Bot1.GetComponent<traiphai>();
        traiphaibot2 = Bot2.GetComponent<traiphai>();
        traiphaibot3 = Bot3.GetComponent<traiphai>();
        traiphai = GetComponent<traiphai>();
        string charName = PlayerPrefs.GetString("CharSelect", "");
        

            if(charName=="Panda")
        {
            Select = Char[5];
        }    
            else if (charName=="chon")
        {
            Select = Char[0];
        }
        else if (charName == "canhcut")
        {
            Select = Char[2];
        }
        else if (charName == "meo")
        {
            Select = Char[1];
        }
        else if (charName == "cho")
        {
            Select = Char[4];
        }
        else if (charName == "gau")
        {
            Select = Char[3];
        }
        traiphai.Char = Select;
        
        Charbot = Char;
        for (int i = 0; i < Charbot.Length; i++)
        {
            if (Charbot[i] == Select)
            {
                
                Char[] newArray = new Char[Charbot.Length - 1];
                for (int j = 0, k = 0; j < Charbot.Length; j++)
                {
                    if (j != i)
                    {
                        newArray[k] = Charbot[j];
                        k++;
                    }
                }
                Charbot = newArray;
                
            }
        }
        traiphaibot1.Char = Charbot[0];
        traiphaibot2.Char = Charbot[1];
        traiphaibot3.Char = Charbot[2];


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
