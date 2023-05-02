using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceManager : Singleton<FenceManager>
{
    [SerializeField] FenceObj[] fences;
    public Mesh[] meshs;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var fence in fences)
        {
            fence.Show();
        }
    }
}