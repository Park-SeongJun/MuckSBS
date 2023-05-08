using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceObj : MonoBehaviour
{
    public int needCount = 0;
    public string needItemName = "�볪��";

    public void Build()
    {
        Hide();
    }
    public void Hide()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;

        transform.GetChild(0).GetComponent<Fence>().Show();
    }
    public void Show()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<MeshCollider>().enabled = true;

        transform.GetChild(0).GetComponent<Fence>().Hide();
    }
    
}
