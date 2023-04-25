using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public float HP { get; set; }

    void Start()
    {
        HP = 10;
    }

    public void Hit(float dmg)
    {
        HP -= dmg;

        if(HP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
