using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRay : MonoBehaviour
{
    Collider other;

    public Image image;

    public bool img = false;

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
                Debug.Log(other);
                Debug.Log(gameObject);
                Debug.Log(tag);
                switch (other.gameObject.tag)
                {
                    case "hunting":
                        other.GetComponent<Tree>().HideTree();
                        break;
                }
            }            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "hunting":
                UI.Instance?.ShowInputUI(true);
                this.other = other;
                break;
        }
    }
    void OnTriggerExit(Collider other)
    {
        UI.Instance?.ShowInputUI(false);
        this.other = null;
    }
}
