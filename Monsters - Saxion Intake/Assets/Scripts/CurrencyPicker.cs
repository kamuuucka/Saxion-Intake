using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPicker : MonoBehaviour
{
    public int worth = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            LevelManager.instance.IncreaseCurrency(worth);
        }
    }
}
