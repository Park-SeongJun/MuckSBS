using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private TMP_Text cntTxt;
    [SerializeField] private Image icon; // Image Component를 담을 곳
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
    /// 데이터 변경
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
    /// 아이템 갯수 변경
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
