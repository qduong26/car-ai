using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroysau(3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
    IEnumerator destroysau(float sogiay)
    {
        yield return new WaitForSeconds(sogiay);
        Destroy(gameObject);
    }
}
