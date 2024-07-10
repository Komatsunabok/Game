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
        // �{�^����OnClick�C�x���g��change_button���\�b�h��ǉ�
        startButton.onClick.AddListener(change_button);
    }
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ�Ƃ��Ƀ{�^���̃N���b�N�C�x���g���Ăяo��
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
