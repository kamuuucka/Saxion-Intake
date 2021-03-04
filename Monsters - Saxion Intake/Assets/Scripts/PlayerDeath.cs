using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void Update()
    {
        FindObjectOfType<LevelManager>().EndGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))   //if player walks into the enemy, dies
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
            LevelManager.instance.IncreaseCurrency(-50);
        }
    }
    
}
