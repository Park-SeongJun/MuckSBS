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
        /*Vector3 rayPos = transform.position;
        rayPos.y += 0.3f;

        //Ray ray = new Ray(rayPos, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(rayPos, transform.forward * 1f, Color.red);

        UI.Instance?.ShowInputUI(false);

        if (Physics.Raycast(rayPos, transform.forward * 1f, out hit, 2f))
        {
            if (hit.collider.CompareTag("hunting"))
            {
                UI.Instance?.ShowInputUI(true);
                Debug.Log(hit.collider.name);
            }            
        }*/
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
