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
        SceneManager.LoadScene(0);
    }
    public void choi()
    {
        SceneManager.LoadScene(1);
        
    }
    public void choilai()
    {
        SceneManager.LoadScene(1);
      
    }
    public void thoat()
    {
        Application.Quit();
    }
}
