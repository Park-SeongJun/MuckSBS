using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    enum State
    {
        idle,
        start,
        end
    }

    [SerializeField] Transform head;
    [SerializeField] Transform mount;

    [SerializeField] TurretBullet tb;
    [SerializeField] Transform tempParent;
    [SerializeField] Transform parent;
    public float dis;
    Animator animator;
    State state = State.idle;


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
        Enemy e = FindEnemy();
        if(e == null)
        {
            if(state ! = State.end)
            {
                CancelInvoke("FireBullet");
                animator.SetTrigger("end");
                state = State.end;
            }
        }
        else
        {
            if (state != State.start)
            {
                animator.SetTrigger("start");
                state = State.start;

                CancelInvoke("FireBullet");
                InvokeRepeating("FireBullet", 2f, 0.5f);
            }

            head.LookAt(e.transform);

            Vector3 vec = e.transform.position - mount.transform.position;
            Quaternion q = Quaternion.LookRotation(vec).normalized;
        }
        
        float dis = Vector3.Distance(turret.position, player.position);

        if (dis <= 3)
        {
            animator.SetTrigger("start");
            //state = State.start;
        }
        else if (dis > 3)
        {
            animator.SetTrigger("end");
            //state = State.end;
        }
    }

    void FireBullet()
    {
        TurretBullet b = Instantiate(tb, tempParent);
        b.transform.SetParent(parent);
    }

    Enemy FindEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");

        float dis = float.MaxValue;
        Enemy e = null;
        foreach (var obj in objs)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if(dis > distance)
            {
                dis = distance;
                e = obj.GetComponent<Enemy>();
            }
        }

        if(e != null)
        {
            float distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance < 25)
            {
                return e;
            }
        }
        return null;
    }
}
