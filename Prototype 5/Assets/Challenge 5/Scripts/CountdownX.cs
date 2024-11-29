using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownX : MonoBehaviour
{
    public int timeRemaining = 60;
    public Text timerText;
    private GameManagerX gameManager;

    private bool isCountingDown = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerX>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown(){
        while (timeRemaining > 0 && isCountingDown)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }

        if (timeRemaining <= 0)
        {
            UpdateTimerText();
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + timeRemaining;
        }
    }
}
