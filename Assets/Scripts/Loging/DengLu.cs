using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DengLu : MonoBehaviour
{
    //登录 账号  密码框
    public InputField UserName1;
    public InputField PossWord2;
    public Button ZCBut;
    public Button DengLuBut;

    //注册账号 密码输入框
    public InputField UserName;
    public InputField PossWord;
    //注册按钮
    public Button ZhuCeBut;
    //注册弹框
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
                //获取输入的账号密码
                string usName = UserName.text;
                string password = PossWord.text;

                //将账号密码存在本地
                PlayerPrefs.SetString("usName", usName);
                PlayerPrefs.SetString("password", password);
                PlayerPrefs.Save();
                Debug.Log("账号密码已经保存");
              
                zcTips.SetActive(false);
            }
            else
            {
                Debug.Log("账号密码为空");
            }
            
        });
      


    }
    private void OnDengLuClick()
    {
        //获取输入的账号密码
        string inputUsername = UserName1.text;
        string inputPossWord = PossWord2.text;

        //从PlayerPrefs中获取保存的账号密码
        string savedUsername = PlayerPrefs.GetString("usName", "");
        string savedPassword = PlayerPrefs.GetString("password", "");

        if(inputUsername == savedUsername && inputPossWord == savedPassword)
        {
            Debug.Log("登录成功");
            //跳转场景
            SceneManager.LoadSceneAsync("MainScene");
        }
        else
        {
            Debug.Log("账号或密码错误");
        }
    }

   

    void Update()
    {
        
    }
}
