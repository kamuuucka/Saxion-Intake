
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreUI;
    private float score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetFloat("score");
        scoreUI.text = score.ToString();

    }
}
