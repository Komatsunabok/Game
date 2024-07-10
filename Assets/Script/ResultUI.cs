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
            Debug.LogError("EscapeButton または RetryButton が見つかりません。ボタン名を確認してください。");
            return;
        }

        // ボタンのクリックイベントを設定
        escapeButton.onClick.AddListener(OnEscapeButtonClicked);
        retryButton.onClick.AddListener(OnRetryButtonClicked);

        // 初期選択ボタンの設定
        selectedButton = retryButton;
        HighlightButton(selectedButton);
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "SCORE: " + playerScript.score;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 選択ボタンの切り替え
            selectedButton = (selectedButton == escapeButton) ? retryButton : escapeButton;
            HighlightButton(selectedButton);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スペースキーで選択中のボタンをクリック
            selectedButton.onClick.Invoke();
        }
    }

    private void HighlightButton(Button button)
    {
        // 全てのボタンの選択状態を解除
        EventSystem.current.SetSelectedGameObject(null);

        // 選択中のボタンを強調表示
        button.GetComponent<Image>().color = Color.white; // 選択されたボタンの色を黄色に変更
        EventSystem.current.SetSelectedGameObject(button.gameObject);

        // 非選択のボタンの色を元に戻す
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
        // ゲーム終了処理
        Application.Quit();
    }

    private void OnRetryButtonClicked()
    {
        // スタート画面に戻る
        SceneManager.LoadScene("StartScene");
    }
}
