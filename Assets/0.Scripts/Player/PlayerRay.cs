using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRay : MonoBehaviour
{
    Collider other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ä�� ����
        if (Input.GetKeyDown(KeyCode.F))
        {            
            if (UI.Instance == null)
                return;

            if (UI.Instance.inputUI.activeInHierarchy)
            {
                switch (other.gameObject.tag)
                {
                    case "hunting":
                        Hunting();                        
                        break;

                    case "buildx":
                        BuildX();
                        break;

                }
            }            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hunting"))
        {
            UI.Instance.ShowInputUI(true);
            this.other = other;
        }
    }
    void OnTriggerExit(Collider other)
    {
        UI.Instance.ShowInputUI(false);
        this.other = null;
    }

    void Hunting()
    {
        if (other.GetComponent<Rock>() != null)
        {
            other.GetComponent<Rock>().HideRock();
        }
        if (other.GetComponent<Tree>() != null)
        {
            other.GetComponent<Tree>().HideTree();
        }
        if (other.GetComponent<Rock>() != null)
        {
            other.GetComponent<Rock>().HideRock();
        }
        if (other.GetComponent<Rock>() != null)
        {
            other.GetComponent<Rock>().HideRock();
        }
    }

    void BuildX()
    {
        if (other.GetComponent<FenceObj>() != null)
        {
            other.GetComponent<FenceObj>().Build();
        }
    }
}
