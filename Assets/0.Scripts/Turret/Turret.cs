using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform turret;
    public float Distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTurret();
    }

    public void SetTurret()
    {
        Distance = (Vector3.Distance(player.position, turret.position));
        animator.SetTrigger("start");
        if (Distance <= 5)
        {

        }
        if (Distance > 5)
        {

        }
    }

    Animator animator;
}
