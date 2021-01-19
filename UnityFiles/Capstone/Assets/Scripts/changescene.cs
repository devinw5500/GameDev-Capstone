using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Levels");
    }
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadOne()
    {
        Debug.Log("load1");
        SceneManager.LoadScene("One");
    }
    public void LoadTwo()
    {
        Debug.Log("load2");
        SceneManager.LoadScene("Two");
    }
    public void LoadThree()
    {
        Debug.Log("load3");
        SceneManager.LoadScene("Three");
    }
    public void LoadFour()
    {
        Debug.Log("load4");
        SceneManager.LoadScene("Four");
    }
}
