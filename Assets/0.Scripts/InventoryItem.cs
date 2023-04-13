using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TMP_Text cntTxt;
    [SerializeField] private Image icon; // Image Component�� ���� ��
    [SerializeField] private TMP_Text nameTxt;

    public int Count { get; set; }
    public string ItemName { get; set; }

    ItemData iData;

    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
    }
    /// <summary>
    /// ������ ����
    /// </summary>
    /// <param name="data"></param>
    public void SetData(ItemData data)
    {
        iData = data;
        SetCount(1, true);
        SetIcon();
        SetName();
    }
    /// <summary>
    /// ������ ���� ����
    /// </summary>
    
    public void SetCount(int count, bool isAdd)
    {
        int temp = isAdd == true ? Count += count : Count -= count;
        cntTxt.text = Count.ToString();
    }
    void SetIcon()
    {
        icon.enabled = true;
        icon.sprite = iData.Icon;
    }
    void SetName()
    {
        nameTxt.text = iData.Name;
        ItemName = iData.Name;
    }
}
