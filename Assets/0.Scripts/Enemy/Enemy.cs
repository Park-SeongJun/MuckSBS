using System;
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
        public float atkDelay;       
        public State state;
        public Transform target;
        public Animator animator;
        public float HP { get; set; }
    }

    protected Data data = new Data();

    float attackTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        Move();
    }

    private void Move()
    {
        transform.LookAt(data.target);
        float dis = Vector3.Distance(transform.position, data.target.position);
        if(dis < 3)
        {
            attackTimer += Time.deltaTime;
            if(attackTimer > data.atkDelay)
            {
                attackTimer = 0f;

                int rand = UnityEngine.Random.Range(1, 3);
                data.animator.SetTrigger($"Attack1{rand}");
                if (data.target.GetComponent<Fence>())
                {
                    data.target.GetComponent<Fence>().Hit(10);
                }
                //히트(데미지) 제공
                //Invoke("FindTarget", 0.5f);
            }
            data.animator.SetBool("Idle", true);
            data.animator.SetBool("Walk Forward", false);
        }
        else if(dis <6)
        {
            data.animator.SetBool("Idle", false);
            data.animator.SetBool("RunForward", false);
            data.animator.SetBool("Walk Forward", true);
            transform.Translate(Vector3.forward * Time.deltaTime * data.spd);
        }
        else
        {
            data.animator.SetBool("Idle", false);
            data.animator.SetBool("RunForward", true);
            data.animator.SetBool("Walk Forward", false);
            transform.Translate(Vector3.forward * Time.deltaTime * data.spd);
        }
    }

    private void FindTarget()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("build");

        float dis = float.MaxValue;
        GameObject obj = null;
        foreach (var target in objs)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (dis > distance)
            {
                dis = distance;
                obj = target;
            }
        }

        data.target = obj.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TurretBullet>())
        {
            data.HP -= other.GetComponent<TurretBullet>().Dmg;

            if(data.HP <= 0)
            {
                Destroy(gameObject);
            }
            other.GetComponent<TurretBullet>();
        }
    }
}
