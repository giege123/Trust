using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public GameObject Player;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Health hp;
    void Awake()
    {
        hp = gameObject.GetComponent<Health>();
    }
    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void Update()


    {
        health = hp.health;

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        if (health <= 0)
        {
            hp.Die();
        }



        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
