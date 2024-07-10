using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Button startButton;
    void Start()
    {
        startButton = GameObject.Find("StartButton")?.GetComponent<Button>();
        // ボタンのOnClickイベントにchange_buttonメソッドを追加
        startButton.onClick.AddListener(change_button);
    }
    void Update()
    {
        // スペースキーが押されたときにボタンのクリックイベントを呼び出す
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (startButton != null)
            {
                startButton.onClick.Invoke();
            }
        }
    }
    public void change_button()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
