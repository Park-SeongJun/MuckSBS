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
                        other.GetComponent<Rock>().HideRock();
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
}
