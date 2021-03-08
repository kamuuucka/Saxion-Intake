﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPicker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            LevelManager.instance.FinishGame();
        }
    }
}
