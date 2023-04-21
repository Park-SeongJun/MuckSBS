using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private GameObject mushroom;

    [HideInInspector] public float resetTime = 2f;

    float delay = 0;
    bool isHide = false;

    public void HideMushroom()
    {
        if (!mushroom.activeInHierarchy)
            return;

        mushroom.SetActive(false);
        isHide = true;

        GameManager.inventory.AddItem((int)ItemType.Mushroom);
    }

    public void ShowMushroom()
    {
        mushroom.SetActive(true);
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
            ShowMushroom();
        }
    }
}
