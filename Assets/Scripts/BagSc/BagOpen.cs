using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagOpen : MonoBehaviour
{
    public GameObject bggTips;
    public Button bagBut;
    int a = 0;
    void Start()
    {
        bagBut.onClick.AddListener(() =>
        {
            a++;
            if(a%2 != 0)
            {
                bggTips.SetActive(true);
            }
            else{
                bggTips.SetActive(false);
            }
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
