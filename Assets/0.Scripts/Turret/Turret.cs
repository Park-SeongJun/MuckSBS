using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform turret;
    public float dis;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(turret.position, player.position);

        if (dis <= 3)
        {
            animator.SetTrigger("start");
        }
        else if (dis > 3)
        {
            animator.SetTrigger("end");
        }
    }
}
