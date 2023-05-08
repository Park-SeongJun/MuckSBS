using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRay : MonoBehaviour
{
    Collider other;
    FenceObj fObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 채집 가능
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

                    /*case "build":
                        Fence();
                        break;*/


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
        UI.Instance?.ShowInputUI(false);
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
        if (other.GetComponent<Stick>() != null)
        {
            other.GetComponent<Stick>().HideStick();
        }
        if (other.GetComponent<Mushroom>() != null)
        {
            other.GetComponent<Mushroom>().HideMushroom();
        }
    }

    void BuildX()
    {
        if (other.GetComponent<FenceObj>() != null)
        {
            FenceObj fObj = other.GetComponent<FenceObj>();
            if (GameManager.inventory.DeleteItem(fObj.needItemName, fObj.needCount))
            {
                fObj.Build();
            }
                
            else
            {
                UI.Instance.ToastPopup($"{fObj.needItemName}, {fObj.needItemName}개가 필요합니다.");
            }
        }
    }

    /*void Fence()
    {
        if (other.GetComponent<Fence>() != null)
        {
            Fence fence = other.GetComponent<Fence>();
            if (GameManager.inventory.DeleteItem(fObj.needItemName, fObj.needCount))
            {
                fObj.Build();
            }

            else
            {
                UI.Instance.ToastPopup($"{fObj.needItemName}, {fObj.needItemName}개가 필요합니다.");
            }
        }
    }*/
}
