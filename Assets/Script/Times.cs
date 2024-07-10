using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Times : MonoBehaviour
{
    //�J�E���g�_�E��
    private const float timelimit = 5.0f;
    private float countdown;

    int score;

    //���Ԃ�\������Text�^�̕ϐ�
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
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        //���Ԃ�\������
        UpdateCountdownText();

        //countdown��0�ȉ��ɂȂ����Ƃ�
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