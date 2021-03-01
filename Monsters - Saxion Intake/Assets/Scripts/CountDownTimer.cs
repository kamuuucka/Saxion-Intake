using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private float startTime = 5f;

    [SerializeField] private TextMeshProUGUI timerText;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;

            FormatText();
            
            yield return null;
        } while (timer > 0);
    }

    private void FormatText()
    {
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);

        timerText.text = "";
        if (minutes > 0)
        {
            if (minutes > 9)
            {
                timerText.text += minutes + ":";
            }
            else
            {
                timerText.text += "0" + minutes + ":";
            }
        }
        else
        {
            timerText.text = "00:";
        }

        if (seconds > 0)
        {
            if (seconds > 9)
            {
                timerText.text += seconds;
            }
            else
            {
                timerText.text += "0" + seconds;
            }
        }
        else
        {
            timerText.text = "00";
        }
    }
}
