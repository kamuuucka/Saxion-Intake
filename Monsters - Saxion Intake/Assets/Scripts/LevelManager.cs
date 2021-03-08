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

   [Header("Heads")] 
   public GameObject head1;
   public GameObject head2;
   public GameObject head3;

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

   public void FinishGame()
   {
      SceneManager.LoadScene("GameWin");
      Debug.Log(currency);
      PlayerPrefs.SetFloat("score", currency);
   }

   public void ShowHeads(int head)
   {

      bool activeHead1 = false;
      bool activeHead2 = false;
      bool activeHead3 = false;
      
      switch (head)
      {
         case 1:
            activeHead1 = true;
            activeHead2 = false;
            activeHead3 = false;
            break;
         case 2:
            activeHead1 = false;
            activeHead2 = true;
            activeHead3 = false;
            break;
         case 3:
            activeHead1 = false;
            activeHead2 = false;
            activeHead3 = true;
            break;
         default:
            break;
      }
      head1.SetActive(activeHead1);
      head2.SetActive(activeHead2);
      head3.SetActive(activeHead3);
      
   }
}
