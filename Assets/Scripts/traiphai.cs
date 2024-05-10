using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traiphai : MonoBehaviour

{
    public Char Char;
    TopDownCarController TopDownCarController;
    private SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        TopDownCarController = GetComponentInParent<TopDownCarController>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Char.thuong;
    }

    // Update is called once per frame
    void Update()
    {
        if (TopDownCarController.steeringInput==1)
        {
            SpriteRenderer.sprite = Char.phai;
        }   
        else if (TopDownCarController.steeringInput == -1)
        {
            SpriteRenderer.sprite = Char.trai;
        }    
        else
        {
            SpriteRenderer.sprite = Char.thuong;
        }
        

    }
}
