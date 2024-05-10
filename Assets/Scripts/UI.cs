using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void vemenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void choimoi()
    {
        SceneManager.LoadScene(1);
        
    }
    public void choilai()
    {
        SceneManager.LoadScene(4);

    }

    public void records()
    {
        SceneManager.LoadScene(5);

    }
    public void thoat()
    {
        Application.Quit();
    }
}
