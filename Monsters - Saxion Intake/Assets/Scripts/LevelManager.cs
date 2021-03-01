using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
   public static LevelManager instance;
   
   public Transform respawnPoint;
   public GameObject playerPrefab;

   [Header("Currency")]
   public int currency = 0;
   public Text currencyUI;
   
   private void Awake()
   {
      instance = this;
   }

   public void Respawn()
   {
      Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
   }

   public void IncreaseCurrency(int amount)
   {
      currency += amount;
      if (currency < 0)
      {
         currency = 0;
         currencyUI.text = currency.ToString();
      }
      else
      {
         currencyUI.text = currency.ToString();
      }
      
   }
}
