using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Mainmenu : MonoBehaviour
{
    public Button theButton;

    bool saveexist = false;
    void Start()
    {
        theButton.interactable = false;
        CheckForSave();
        if (saveexist)
        {
            theButton.interactable = true;

        }
    }
    public void CheckForSave()
    {

    }
    public void Options()
    {
        SceneManager.LoadScene("Option");
    }
    public void Continue()
    {
        if (saveexist)
        {
            SceneManager.LoadScene("Option");//Nurodyti reiks tarp saved reiksme, kur yra tarp skliaustu  
        }

    }
    public void Startnew()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
