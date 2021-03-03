using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    private int enemyHealth = 20;
    public Renderer myObject;
    private Color red = Color.red;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))   //if enemy gets shot, dies
        {
            enemyHealth -= 5;
            ChangeColorToRed();
            Invoke("ChangeColorToWhite", 0.2f);
        }

        if (enemyHealth <= 0)
        {
            ChangeColorToRed();
            Destroy(gameObject);
        }
    }

    private void ChangeColorToRed()
    {
        red.a = 0.5f;
        myObject.material.color = red;
    }

    private void ChangeColorToWhite()
    {
        myObject.material.color = Color.white;
    }
}
