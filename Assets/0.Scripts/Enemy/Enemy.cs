using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected enum State
    {
        Idle,
        Walk,
        Attack,
        Die,
    }
    protected struct Data
    {
        public float spd;
        public State state;
        public Transform target;
        public Animator animator;
    }

    protected Data data = new Data();

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.LookAt(data.target);
        float dis = Vector3.Distance(transform.position, data.target.position);
        if(dis < 3)
        {
            data.animator.SetBool("RunForward", false);
            data.animator.SetBool("Walk Forward", false);
        }
        else if(dis <6)
        {
            data.animator.SetBool("RunForward", false);
            data.animator.SetBool("Walk Forward", true);
            transform.Translate(Vector3.forward * Time.deltaTime * data.spd);
        }
        else
        {
            data.animator.SetBool("RunForward", true);
            data.animator.SetBool("Walk Forward", false);
            transform.Translate(Vector3.forward * Time.deltaTime * data.spd);
        }
    }
}
