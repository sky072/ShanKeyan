using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrace : MonoBehaviour
{
    //�������Ŀ��
    public Transform traget;
    //ƫ����
    public Vector3 offset = new Vector3(0, 3, -6);
    //�ٶ�
    public float smoothSpeed = 5f;


    private void LateUpdate()
    {
        if (traget == null) return;
        Vector3 desiredPostation = traget.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPostation,smoothSpeed * Time.deltaTime);
        //���ʼ�տ������
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
