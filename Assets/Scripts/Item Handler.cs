using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public bool issmall = false;
    public bool isbig = false;
    public bool isthrough = false;
    public bool isspeedup = false;
    public bool baove = false;
    public bool vodich = false;
    private Animator animator;
    public GameObject effect;
    GameObject gameobject;
    Vector3 originalScale ;
    Vector3 vitrisp;
    TopDownCarController topDownCarController;
    Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = effect.GetComponent<Animator>();
        topDownCarController = GetComponent<TopDownCarController>();
        gameobject = gameObject;
        originalScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(isspeedup || vodich)
        { 
            Rigidbody2D.AddForce(transform.up * 0.05f, ForceMode2D.Impulse);
        }
        
    }
   public void small()
    {
        
            issmall = true;
            StartCoroutine(ScaleDownAndRestore(gameobject)); 
    }    
    public void big()
    {
        
            isbig = true;
            StartCoroutine(ScaleUpAndRestore(gameobject));
        
    }
    public void through()
    {
        
            isthrough = true;

            StartCoroutine(Through(gameobject));
        
    }
    public void speedup() {
        
            isspeedup = true;

            StartCoroutine(Speedup(gameobject));
        
    }
    public void Shield()
    {
        
           
            baove = true;
            StartCoroutine(shield());
        
    }
    public void star()
    {
        
            vodich = true;

            StartCoroutine(Star());
        
    }
    public void min(GameObject min)
    {
        vitrisp = gameobject.transform.position - 3f * gameObject.transform.up;
        Instantiate(min, vitrisp, Quaternion.identity);

    }
    
    public void dan(GameObject dan)
    {
        vitrisp = gameobject.transform.position + 3f * gameObject.transform.up;
        Instantiate(dan, vitrisp, Quaternion.identity);

    }
    
    IEnumerator ScaleDownAndRestore(GameObject gameobject)
    {
        
        
        while (issmall)
        {

            while (gameobject.transform.localScale.x > originalScale.x / 2 && issmall)
            {
                gameobject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                yield return new WaitForSeconds(0.1f);
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

       
        yield return new WaitForSeconds(5f);
        
        isspeedup = false;

    }
    IEnumerator shield()
    {
        animator.SetInteger("Effect", 1);
      


        yield return new WaitForSeconds(5f);

        animator.SetInteger("Effect", 0);
        baove = false;
    }
    IEnumerator Star()
    {
        animator.SetInteger("Effect", 2);



        yield return new WaitForSeconds(5f);

        animator.SetInteger("Effect", 0);
        vodich = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "car")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            ItemHandler itemHandler = collision.gameObject.GetComponent<ItemHandler>();
            if (vodich &&(itemHandler.vodich == false && itemHandler.baove == false))
            {
                Vector2 hitDirection = (transform.position - collision.transform.position).normalized;

                rb.AddForce(-hitDirection * 6f, ForceMode2D.Impulse);
            }
        }
    }
}
