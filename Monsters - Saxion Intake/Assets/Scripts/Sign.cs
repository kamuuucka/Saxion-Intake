using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    //public string dialog;
    public bool playerInRange;
    
    void Update()
    {
        if (playerInRange == true)
        {
            Debug.Log("Player in range");
            if (!dialogBox.activeInHierarchy)
            {
                Debug.Log("BoxActive");
                dialogBox.SetActive(true);
                //dialogText.text = dialog;
            }
        }
        else
        {
            Debug.Log("Box inactive");
            dialogBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
