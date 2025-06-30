using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatEnmey : MonoBehaviour
{
     GameObject Enemy;
    int a = 3;

    void Start()
    {
        Enemy = Resources.Load<GameObject>("Enemy");
        for(int i = 0; i < a; i++)
        {
            GameObject go = Instantiate(Enemy);
            go.transform.position = new Vector3(Random.Range(-25, 25), 0.5f, Random.Range(-25, 25));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
