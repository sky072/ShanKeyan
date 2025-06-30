using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
public enum EnemyType
{
    MOVE,
    STOP,
    ATTACK,
}

public class AIMove : MonoBehaviour
{
    public EnemyType enemyMove;
    public Transform[] waypoints;
    public float speed = 2;
    public int currentIndex = 0;
    private Animator enemyAni;
    GameObject player;
    Transform p1;
    Transform p2;
    Transform p3;

    void Start()
    {
        p1 = GameObject.Find("AIPostation/ap1").transform;
        p2 = GameObject.Find("AIPostation/ap1").transform;
        p3 = GameObject.Find("AIPostation/ap1").transform;
        player = GameObject.Find("Player");
        enemyAni = transform.GetComponent<Animator>();
        waypoints = new Transform[3];
        waypoints[0] = p1;
        waypoints[1] = p2;
        waypoints[2] = p3;

    }

    // Update is called once per frame
    void Update()
    {
        EnemyAIMove();
        SetAni();
    }

    private void EnemyAIMove()
    {
        if (waypoints.Length == 0) return;
        Transform target = waypoints[currentIndex];
        transform.LookAt(waypoints[currentIndex]);
        enemyMove = EnemyType.MOVE;
        if (Vector3.Distance(player.transform.position, transform.position)<=5)
        {
            transform.LookAt(player.transform.position);
            Vector3 dir = (player.transform.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
            if (Vector3.Distance(player.transform.position, transform.position) <= 2)
            {
                transform.LookAt(player.transform);
                
                enemyMove = EnemyType.ATTACK;
            }
        }
        else
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                currentIndex = (currentIndex + 1) % waypoints.Length;
            }
        }
    }
    private void SetAni()
    {
        if (enemyMove == EnemyType.MOVE)
        {
            enemyAni.Play("Run");
        }else if (enemyMove == EnemyType.STOP)
        {
            enemyAni.Play("IdleC");

        }
        else if(enemyMove==EnemyType.ATTACK)
        {
            enemyAni.Play("Skill10052");
        }
    }
}
