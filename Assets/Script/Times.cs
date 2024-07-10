using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Times : MonoBehaviour
{
    //カウントダウン
    private const float timelimit = 5.0f;
    private float countdown;

    int score;

    //時間を表示するText型の変数
    public TextMeshProUGUI timeText;

    GameObject gameplay = GameObject.FindWithTag("Gameplay");
    GameObject timeObject;
    GameObject scoreObject = GameObject.FindWithTag("Score");

    private void Start()
    {
        timeObject = gameObject;
        timeText = timeObject.GetComponent<TextMeshProUGUI>();

        countdown = timelimit;
        UpdateCountdownText();
        
        scoreObject.SetActive(true);
        timeObject.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        UpdateCountdownText();

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            scoreObject.SetActive(false);
            timeObject.SetActive(false);


            timeText.text = "Time UP!";

            //endObject.SetActive(true);

            //GameObject scoreObject = GameObject.FindWithTag("FinalScore");
            //scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            //GameObject playerObject = GameObject.FindWithTag("Player");
            //PlayerScript playerScript = playerObject.GetComponent<PlayerScript>();
            //scoreText.text = "" + playerScript.score;
        }
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(countdown / 60);
        int seconds = Mathf.FloorToInt(countdown % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}