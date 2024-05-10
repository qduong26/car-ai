using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelect : MonoBehaviour
{
    
    public void Chonpanda()
    {
        PlayerPrefs.SetString("CharSelect", "Panda");
        SceneManager.LoadScene(2);
    }
    public void Chonchon()
    {
        PlayerPrefs.SetString("CharSelect", "chon");
        SceneManager.LoadScene(2);
    }
    public void Chonmeo()
    {
        PlayerPrefs.SetString("CharSelect", "meo");
        SceneManager.LoadScene(2);
    }
    public void Choncanhcut()
    {
        PlayerPrefs.SetString("CharSelect", "canhcut");
        SceneManager.LoadScene(2);
    }
    public void Choncho()
    {
        PlayerPrefs.SetString("CharSelect", "cho");
        SceneManager.LoadScene(2);
    }
    public void Chongau()
    {
        PlayerPrefs.SetString("CharSelect", "gau");
        SceneManager.LoadScene(2);
    }
    public void Chonmap1()
    {
        PlayerPrefs.SetString("MapSelect", "map1");
        SceneManager.LoadScene(3);
    }
    public void Chonmap2()
    {
        PlayerPrefs.SetString("MapSelect", "map2");
        SceneManager.LoadScene(3);
    }
        public void Chonmap3()
        {
            PlayerPrefs.SetString("MapSelect", "map3");
            SceneManager.LoadScene(3);
        }
    public void Chonmap4()
    {
        PlayerPrefs.SetString("MapSelect", "map4");
        SceneManager.LoadScene(3);
    }
    public void Chon1vong()
    {
        PlayerPrefs.SetInt("sovong", 1);
        SceneManager.LoadScene(4);
    }
    public void Chon2vong()
    {
        PlayerPrefs.SetInt("sovong", 2);
        SceneManager.LoadScene(4);
    }
    public void Chon3vong()
    {
        PlayerPrefs.SetInt("sovong", 3);
        SceneManager.LoadScene(4);
    }

}
