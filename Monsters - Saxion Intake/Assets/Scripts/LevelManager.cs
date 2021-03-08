using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
   private bool gameHasEnded = false;
   
   public static LevelManager instance;
   
   public Transform respawnPoint;
   public GameObject playerPrefab;

   public CinemachineVirtualCameraBase cam;

   [Header("Currency")]
   public int currency = 50;
   public Text currencyUI;
   
   private void Awake()
   {
      instance = this;
   }

   public void Respawn()
   {
      GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
      cam.Follow = player.transform;
      PlayerMovement.canShoot = true;
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
   
   public void EndGame()
   {
      if (!gameHasEnded)
      {
         if (currency <= 0)
         {
            gameHasEnded = true;
            //Debug.Log("GAME OVER");
            Restart();
         }
      }
   }

   public void Restart()
   {
      SceneManager.LoadScene("GameOver");
   }
}
