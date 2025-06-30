using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PlayerMove
{
    MOVE,
    STOP,
    ATTACK
}

public class SetPlayer : MonoBehaviour
{
    //玩家状态
    PlayerMove playeType;
    //玩家动画效果
    public Animator PlayerAni;
    //移动速度
    public float moveSpeed = 5f;
    //旋转速度
    public float rotateSpeed = 10f;
    //玩家血条
    public Image PlayerHp;
    void Start()
    {
       
        //SetPlayerMove();

    }

    // Update is called once per frame
    void Update()
    {
       
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(h, 0, v);

        if (moveDir.magnitude > 0.1f)
        {
            transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;
            Quaternion toRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation,toRotation , rotateSpeed * Time.deltaTime);
            playeType = PlayerMove.MOVE;
            PlayerAni.Play("running");
        }
        else
        {
            playeType = PlayerMove.STOP;
            PlayerAni.Play("idle");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Root")
        {
            if (PlayerHp.fillAmount == 1)
            {
                SceneManager.LoadSceneAsync("ScendScene");
            }
            else{
                Debug.Log("血量不足，无法进入");
            }
            
        }
    }
    //void SetPlayerMove()
    //{
    //    //设置玩家不同Type下的不同动画状态
    //    if (playeType == PlayerMove.MOVE)
    //    {
    //        PlayerAni.Play("running");
    //    }else if(playeType == PlayerMove.STOP)
    //    {
    //        PlayerAni.Play("idle");
    //    }
    //    else
    //    {
    //        PlayerAni.Play("Attack");
    //    }
    //}
}
