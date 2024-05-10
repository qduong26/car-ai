using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageflash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;

    public bool isflash = false;
    [SerializeField] private float duration;


   

    // The SpriteRenderer that should flash.
    private SpriteRenderer spriteRenderer;

    // The material that was in use, when the script started.
    private Material originalMaterial;

    // The currently running coroutine.
    private Coroutine flashRoutine;

   



    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        originalMaterial = spriteRenderer.material;
       StartCoroutine(FlashCoroutine());
       
    }


    public IEnumerator FlashCoroutine()
    {
        while (true) 
        {
            if (isflash) 
            {
                if (flashRoutine != null)
                {
                    StopCoroutine(flashRoutine); 
                }
                flashRoutine = StartCoroutine(FlashRoutine()); 
            }
            yield return new WaitForSeconds(0.5f); 
        }
    }

    private IEnumerator FlashRoutine()
    {
        // Swap to the flashMaterial.
        spriteRenderer.material = flashMaterial;

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(duration);

        // After the pause, swap back to the original material.
        spriteRenderer.material = originalMaterial;

        // Set the routine to null, signaling that it's finished.
        flashRoutine = null;
    }
    private void Update()
    {
       
    }



}
