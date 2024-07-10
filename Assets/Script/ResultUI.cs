using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    GameObject scoreObject;

    public Button escapeButton;
    public Button retryButton;
    private Button selectedButton;


    // Start is called before the first frame update
    void Start()
    {
        scoreObject = GameObject.FindWithTag("FinalScore");
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

        int score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "SCORE: " + score.ToString();

        escapeButton = GameObject.FindWithTag("EscapeButton")?.GetComponent<Button>();
        retryButton = GameObject.FindWithTag("RetryButton")?.GetComponent<Button>();

        if (escapeButton == null || retryButton == null)
        {
            Debug.LogError("EscapeButton �܂��� RetryButton ��������܂���B�{�^�������m�F���Ă��������B");
            return;
        }

        // �{�^���̃N���b�N�C�x���g��ݒ�
        escapeButton.onClick.AddListener(OnEscapeButtonClicked);
        retryButton.onClick.AddListener(OnRetryButtonClicked);

        // �����I���{�^���̐ݒ�
        selectedButton = retryButton;
        HighlightButton(selectedButton);
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "SCORE: " + playerScript.score;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // �I���{�^���̐؂�ւ�
            selectedButton = (selectedButton == escapeButton) ? retryButton : escapeButton;
            HighlightButton(selectedButton);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �X�y�[�X�L�[�őI�𒆂̃{�^�����N���b�N
            selectedButton.onClick.Invoke();
        }
    }

    private void HighlightButton(Button button)
    {
        // �S�Ẵ{�^���̑I����Ԃ�����
        EventSystem.current.SetSelectedGameObject(null);

        // �I�𒆂̃{�^���������\��
        button.GetComponent<Image>().color = Color.white; // �I�����ꂽ�{�^���̐F�����F�ɕύX
        EventSystem.current.SetSelectedGameObject(button.gameObject);

        // ��I���̃{�^���̐F�����ɖ߂�
        if (button == escapeButton)
        {
            retryButton.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            escapeButton.GetComponent<Image>().color = Color.gray;
        }
    }

    private void OnEscapeButtonClicked()
    {
        // �Q�[���I������
        Application.Quit();
    }

    private void OnRetryButtonClicked()
    {
        // �X�^�[�g��ʂɖ߂�
        SceneManager.LoadScene("StartScene");
    }
}
