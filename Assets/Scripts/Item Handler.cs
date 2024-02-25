using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public bool issmall = false;
    public bool isbig = false;
    public bool isthrough = false;
    public bool isspeedup = false;
    GameObject gameobject;
    Vector3 originalScale ;

    TopDownCarController topDownCarController;
    void Start()
    {
        topDownCarController = GetComponent<TopDownCarController>();
        gameobject = gameObject;
        originalScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void small()
    {
        if (!issmall && !isbig && !isthrough && !isspeedup) {
            issmall = true;
            StartCoroutine(ScaleDownAndRestore(gameobject)); }
    }    
    public void big()
    {
        if (!issmall && !isbig && !isthrough && !isspeedup)
        {
            isbig = true;
            StartCoroutine(ScaleUpAndRestore(gameobject));
        }
    }
    public void through()
    {
        if (!issmall && !isbig && !isthrough && !isspeedup)
        {
            isthrough = true;

            StartCoroutine(Through(gameobject));
        }
    }
    public void speedup() {
        if (!issmall && !isbig && !isthrough && !isspeedup)
        {
            isspeedup = true;

            StartCoroutine(Speedup(gameobject));
        }
    }
    IEnumerator ScaleDownAndRestore(GameObject gameobject)
    {
        
        
        while (issmall)
        {

            while (gameobject.transform.localScale.x > originalScale.x / 2 && issmall)
            {
                gameobject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                yield return new WaitForSeconds(0.001f);
            }


            yield return new WaitForSeconds(5f);


            while (gameobject.transform.localScale.x < originalScale.x && issmall)
            {
                transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                yield return new WaitForSeconds(0.1f);
                ;
            }
            issmall = false;
        }

    }
    IEnumerator ScaleUpAndRestore(GameObject gbject)
    {
       
        while (isbig)
        {

            while (gameobject.transform.localScale.x < originalScale.x * 2 && isbig)
            {
                gameobject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                yield return new WaitForSeconds(0.1f);
            }


            yield return new WaitForSeconds(5f);


            while (gameobject.transform.localScale.x > originalScale.x && isbig)
            {
                gameobject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                yield return new WaitForSeconds(0.1f);
                ;
            }
            isbig = false;
        }

    }
    IEnumerator Through(GameObject gameobject)
    {

        gameobject.layer = LayerMask.NameToLayer("Water");






        float startTime = Time.time;
        Color originalColor = gameobject.GetComponentInChildren<Renderer>().material.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
        while (Time.time - startTime < 2f)
        {
            float t = (Time.time - startTime) / 2f;
            gameobject.GetComponentInChildren<Renderer>().material.color = Color.Lerp(originalColor, targetColor, t);
            yield return null;
        }


        yield return new WaitForSeconds(5f);


        startTime = Time.time;
        while (Time.time - startTime < 2f)
        {
            float t = (Time.time - startTime) / 2f;
            gameobject.GetComponentInChildren<Renderer>().material.color = Color.Lerp(targetColor, originalColor, t);
            yield return null;
        }

        gameobject.layer = LayerMask.NameToLayer("Car");
        isthrough = false;
    }
    IEnumerator Speedup(GameObject gameobject)
    {
        float orignaccelerationFactor = topDownCarController.accelerationFactor;
        topDownCarController.accelerationFactor = orignaccelerationFactor * 2;
        yield return new WaitForSeconds(5f);
        topDownCarController.accelerationFactor = orignaccelerationFactor;
        isspeedup = false;

    }
}
