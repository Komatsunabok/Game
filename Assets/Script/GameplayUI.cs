using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    //�J�E���g�_�E��
    private const float timelimit = 60.0f;
    private float countdown;

    //���Ԃ�\������Text�^�̕ϐ�
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    GameObject gameplay;
    GameObject scoreObject;
    GameObject timeObject;
    GameObject playerObject;
    PlayerScript playerScript;
    GameObject result;
    GameObject treasures;

    public Camera playerCamera;

    private void Start()
    {
        gameplay = gameObject;
        scoreObject = GameObject.FindWithTag("Score");
        timeObject = GameObject.FindWithTag("Time");
        playerObject = GameObject.FindWithTag("Player");
        treasures = GameObject.FindWithTag("Treasures");

        gameObject.SetActive(true);

        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        timeText = timeObject.GetComponent<TextMeshProUGUI>();
        playerScript = playerObject.GetComponent<PlayerScript>();

        scoreText.text = "SCORE: " + playerScript.score;

        countdown = timelimit;
        UpdateCountdownText();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript != null)
        {
            scoreText.text = "SCORE: " + playerScript.score;
        }

        countdown -= Time.deltaTime;
        UpdateCountdownText();

        // countdown��0�ȉ��ɂȂ����Ƃ�
        if (countdown <= 0)
        {
            SaveScore();
            SceneManager.LoadScene("ResultScene");

        }
    }

    void UpdateCountdownText()
    {
        //int minutes = Mathf.FloorToInt(countdown / 60);
        float seconds = countdown % 60; // �b����float�^�Ŏ擾����

        if (timeText != null)
        {
            timeText.text = string.Format("{0:00.00}", seconds);
        }
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", playerScript.score);
        PlayerPrefs.Save();
    }
}
