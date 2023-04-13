using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI Instance;

    public GameObject inputUI;
    [SerializeField] private Transform toastPopup;


    void Awake()
    {
        Instance = this;
    }
    
    public void ShowInputUI(bool isActive)
    {
        inputUI.GetComponent<Image>().fillAmount = 1f;
        inputUI.SetActive(isActive);
    }
    public void InputUIFillAmount(float min, float max)
    {
        inputUI.GetComponent<Image>().fillAmount = min / max;
    }

    public void ToastPopup(string ment)
    {
        toastPopup.GetChild(0).GetComponent<TMP_Text>().text = ment;
        toastPopup.position = new Vector2(0, 10);

        StopCoroutine("Toast");
        StartCoroutine("Toast");
    }

    IEnumerator Toast()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.01f);
            if (toastPopup.localPosition.y > -100)
                toastPopup.localPosition = Vector2.down * 5f;
            else
                break;
        }
        yield return new WaitForSeconds(2f);

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (toastPopup.localPosition.y <= 10)
                toastPopup.Translate(Vector2.up * 10f);
            else
                break;
        }
    }
}
