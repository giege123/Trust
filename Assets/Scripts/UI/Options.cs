using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Options : MonoBehaviour
{

    public void Save()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
