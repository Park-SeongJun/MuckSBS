using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceManager : MonoBehaviour
{
    [SerializeField] FenceObj[] fences;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var fence in fences)
        {
            fence.Show();
        }
    }
}