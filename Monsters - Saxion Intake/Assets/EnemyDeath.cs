using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private int enemyHealth = 20;
    private Renderer rend;
    private float resetTime = 0.5f;

    [SerializeField] 
    private Color colorToTurnTo = Color.red;
    private Color colorBase = Color.white;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))   //if enemy gets shot, dies
        {
            enemyHealth -= 5;
            rend.material.color = colorToTurnTo;
            StartCoroutine("TimeWait", 5f);
            rend.material.color = colorBase;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator TimeWait(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
    }
}
