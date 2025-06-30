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
    //���״̬
    PlayerMove playeType;
    //��Ҷ���Ч��
    public Animator PlayerAni;
    //�ƶ��ٶ�
    public float moveSpeed = 5f;
    //��ת�ٶ�
    public float rotateSpeed = 10f;
    //���Ѫ��
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
                Debug.Log("Ѫ�����㣬�޷�����");
            }
            
        }
    }
    //void SetPlayerMove()
    //{
    //    //������Ҳ�ͬType�µĲ�ͬ����״̬
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
