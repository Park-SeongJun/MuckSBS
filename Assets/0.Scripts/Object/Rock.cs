using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private GameObject rock;

    [HideInInspector] public float resetTime = 2f;

    float delay = 0;
    bool isHide = false;

    public void HideTree()
    {
        if (!rock.activeInHierarchy)
            return;

        rock.SetActive(false);
        isHide = true;

        GameManager.inventory.AddItem((int)ItemType.Stone);
    }

    public void ShowTree()
    {
        rock.SetActive(true);
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
