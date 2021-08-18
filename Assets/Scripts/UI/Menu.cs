using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject gmr;
    bool busena;
    public UnityEvent onCompleteCallback;
    // Start is called before the first frame update
    void Start()
    {
        busena = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && busena == false)
        {
            LeanTween.moveX(gmr.GetComponent<RectTransform>(), -110f, 0.1f).setDelay(0.1f).setOnComplete(() => { busena = true; });
        }
        if (Input.GetKeyDown(KeyCode.Escape) && busena == true)
        {
            LeanTween.moveX(gmr.GetComponent<RectTransform>(), -220f, 0.1f).setDelay(0.1f).setOnComplete(() => { busena = false; });
        }
    }
    public void Resume()
    {
        LeanTween.moveX(gmr.GetComponent<RectTransform>(), -220f, 0.1f).setDelay(0.1f).setOnComplete(() => { busena = false; });
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
}
