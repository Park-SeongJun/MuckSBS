using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [HideInInspector] public float dmg = 10;

    // Start is called before the first frame update
    void Start() => Destroy(gameObject, 3f);

    // Update is called once per frame
    void Update() => transform.Translate(Vector3.forward * Time.deltaTime * 10f);
}
