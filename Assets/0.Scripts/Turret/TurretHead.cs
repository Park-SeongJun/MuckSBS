using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHead : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float range = 60f;
    [SerializeField] private string enemy = "Player";
    [SerializeField] private Transform turretmid;
    [SerializeField] private float turnSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(turretmid.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turretmid.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
