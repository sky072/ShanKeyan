using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DengLu : MonoBehaviour
{
    //��¼ �˺�  �����
    public InputField UserName1;
    public InputField PossWord2;
    public Button ZCBut;
    public Button DengLuBut;

    //ע���˺� ���������
    public InputField UserName;
    public InputField PossWord;
    //ע�ᰴť
    public Button ZhuCeBut;
    //ע�ᵯ��
    public GameObject zcTips;
  
    
    void Start()
    {
        ZCBut.onClick.AddListener(OnLoginClick);
        DengLuBut.onClick.AddListener(OnDengLuClick);
        
    }
    private void OnLoginClick()
    {
        zcTips.SetActive(true);
        ZhuCeBut.onClick.AddListener(() =>
        {
            if(UserName.text != null && PossWord.text != null)
            {
                //��ȡ������˺�����
                string usName = UserName.text;
                string password = PossWord.text;

                //���˺�������ڱ���
                PlayerPrefs.SetString("usName", usName);
                PlayerPrefs.SetString("password", password);
                PlayerPrefs.Save();
                Debug.Log("�˺������Ѿ�����");
              
                zcTips.SetActive(false);
            }
            else
            {
                Debug.Log("�˺�����Ϊ��");
            }
            
        });
      


    }
    private void OnDengLuClick()
    {
        //��ȡ������˺�����
        string inputUsername = UserName1.text;
        string inputPossWord = PossWord2.text;

        //��PlayerPrefs�л�ȡ������˺�����
        string savedUsername = PlayerPrefs.GetString("usName", "");
        string savedPassword = PlayerPrefs.GetString("password", "");

        if(inputUsername == savedUsername && inputPossWord == savedPassword)
        {
            Debug.Log("��¼�ɹ�");
            //��ת����
            SceneManager.LoadSceneAsync("MainScene");
        }
        else
        {
            Debug.Log("�˺Ż��������");
        }
    }

   

    void Update()
    {
        
    }
}
