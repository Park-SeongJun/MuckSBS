using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private GameObject stone;

    [HideInInspector] public float resetTime = 2f;

    float delay = 0;
    bool isHide = false;

    public void HideRock()
    {
        if (!stone.activeInHierarchy)
            return;

        stone.SetActive(false);
        isHide = true;

        GameManager.inventory.AddItem((int)ItemType.Stone);
    }

    public void ShowRock()
    {
        stone.SetActive(true);
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
            ShowRock();
        }
    }
}
