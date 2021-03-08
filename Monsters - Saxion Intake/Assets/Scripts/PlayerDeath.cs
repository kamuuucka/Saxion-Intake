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
            Die(-50);
        }
        else if (collision.gameObject.CompareTag("Water"))
        {
            Die(-100);
        }
        
    }

    private void Die(int damage)
    {
        Destroy(gameObject);
        LevelManager.instance.Respawn();
        LevelManager.instance.IncreaseCurrency(damage);
    }
    
}
