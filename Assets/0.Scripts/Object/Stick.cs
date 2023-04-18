using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private GameObject stick;

    [HideInInspector] public float resetTime = 2f;

    float delay = 0;
    bool isHide = false;

    public void HideTree()
    {
        if (!stick.activeInHierarchy)
            return;

        stick.SetActive(false);
        isHide = true;

        GameManager.inventory.AddItem((int)ItemType.Stone);
    }

    public void ShowTree()
    {
        stick.SetActive(true);
        isHide = false;
    }
    void Update()
    {
        if (!isHide)
            return;

        delay += Time.deltaTime;
        if (delay > resetTime)
        {
            delay = 0;
            ShowTree();
        }
    }
}
