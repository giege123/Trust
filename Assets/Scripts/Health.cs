using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();

        }
    }


    public void Die()
    {
        if (gameObject.CompareTag("Barrel"))
        {
            BoxCollider2D col = gameObject.GetComponent<BoxCollider2D>();
            col.enabled = false;
            Barrel brl = gameObject.GetComponent<Barrel>();
            brl.Destruction();

        }
        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level1");
        }
        if (gameObject.CompareTag("smallenemy"))
        {
            Destroy(gameObject);
        }
    }

}
