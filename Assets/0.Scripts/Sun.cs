using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * 5f);

        if(transform.rotation.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -30, 0f);
        }
    }
}
