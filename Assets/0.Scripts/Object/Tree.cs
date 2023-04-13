using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject btmTree;

    [HideInInspector] public float resetTime = 2f;

    float delay = 0;    
    bool isHide = false;

    public void HideTree()
    {
        if (!tree.activeInHierarchy)
            return;

        tree.SetActive(false);
        isHide = true;

        GameManager.inventory.AddItem(1);
    }

    public void ShowTree()
    {
        tree.SetActive(true);
        isHide = false;
    }
    void Update()
    {
        if (!isHide)
            return;

        delay += Time.deltaTime;
        if(delay > resetTime)
        {
            delay = 0;
            ShowTree();
        }
    }
}
