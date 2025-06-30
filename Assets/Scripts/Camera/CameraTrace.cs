using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrace : MonoBehaviour
{
    //相机跟随目标
    public Transform traget;
    //偏移量
    public Vector3 offset = new Vector3(0, 3, -6);
    //速度
    public float smoothSpeed = 5f;


    private void LateUpdate()
    {
        if (traget == null) return;
        Vector3 desiredPostation = traget.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPostation,smoothSpeed * Time.deltaTime);
        //相机始终看向玩家
        transform.LookAt(traget);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
