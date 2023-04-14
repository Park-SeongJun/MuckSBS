using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemData[] itemData;

    [SerializeField] private InventoryItem prefab;
    [SerializeField] private Transform parent;

    public int YCnt { get; set; }
    public int XCnt { get; set; }

    public bool IsStartSetting { get; set; }

    List<InventoryItem> inventoryItemList = new List<InventoryItem>();

    int lastIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        IsStartSetting = false;
        gameObject.SetActive(false);
    }

        /// <summary>
        /// �κ��丮 ������ UI����
        /// </summary>
    
    private void Setting()
    {
        //�ʹ� �κ��丮 ���� ������ ����
        for (int y = 0; y < YCnt; y++)
        {
            for (int x = 0; x < XCnt; x++)
            {
                inventoryItemList.Add(Instantiate(prefab, parent));
            }
        }
    }
    // Update is called once per frame
   
    /// <summary>
    /// �׽�Ʈ��: ������ �߰�
    /// </summary>
    public void AddItem(int itemIdx)
    {
        if (lastIndex > (XCnt * YCnt) - 1)
            return;

        // ���� ��� �ִ� ������ �κ��丮�� ����
        itemIdx = Random.Range(0, itemData.Length);
        ItemData id = itemData[itemIdx];

        // �������� ���� ������ �� ��
        if (ItemAddCheck(id.Name) == true)
        {
            inventoryItemList[lastIndex].SetData(id);
            lastIndex++;

            UI.Instance.ToastPopup($"{id.name} ��(��) ���� �Ͽ����ϴ�.");
        }
        else
        {
            int idx = ItemFindIndex(id.Name);
            inventoryItemList[idx].SetCount(1, true);

            UI.Instance.ToastPopup($"{id.name} ��(��) 1���� ȹ�� �Ͽ����ϴ�.");
        }
    }

    /// <summary>
    /// ���ο� ���������� üũ
    /// </summary>
    /// 
    private bool ItemAddCheck(string name)
    {
        for (int i = 0;  i < inventoryItemList.Count;  i++)
        {
            if (inventoryItemList[i].ItemName == name)
                return false;
        }
        return true;
    }

    /// <summary>
    /// ���° �������� ����ִ��� Ȯ���� ��ȣ ��ȯ
    /// </summary>
    /// 
    private int ItemFindIndex(string name)
    {
        int index = 0;
        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            if (inventoryItemList[i].ItemName == name)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    /// <summary>
    /// �κ��丮 ȭ���� ������ �� ����Ǵ� �Լ�
    /// </summary>
    public void OnShow()
    {
        gameObject.SetActive(true);
        //GameManager.UIMode(true);
        YCnt = 10;
        XCnt = 4;

        if (!IsStartSetting)
        {
            Setting();
        }
    }

    /// <summary>
    /// �κ��丮 ȭ���� ����
    /// </summary>

    public void OnHide()
    {
        gameObject.SetActive(false);
        // GameManager.UIMode(false);
    }
}
