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
        /// 인벤토리 데이터 UI셋팅
        /// </summary>
    
    private void Setting()
    {
        //초반 인벤토리 백판 아이콘 셋팅
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
    /// 테스트용: 아이템 추가
    /// </summary>
    public void AddItem(int itemIdx)
    {
        /*if (lastIndex > (XCnt * YCnt) - 1)
            return;*/

        // 내가 들고 있는 아이템 인벤토리에 셋팅
        itemIdx = Random.Range(0, itemData.Length);
        ItemData id = itemData[itemIdx];

        // 아이템을 새로 만들어야 할 때
        if (ItemAddCheck(id.Name) == true)
        {
            inventoryItemList[lastIndex].SetData(id);
            lastIndex++;

            UI.Instance.ToastPopup($"{id.name} 을(를) 습득 하였습니다.");
        }
        else
        {
            int idx = ItemFindIndex(id.Name);
            inventoryItemList[idx].SetCount(1, true);

            UI.Instance.ToastPopup($"{id.name} 을(를) 1개를 획득 하였습니다.");
        }
    }

    /// <summary>
    /// 새로운 아이템인지 체크
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
    /// 몇번째 아이템이 들어있는지 확인후 번호 반환
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
    /// 인벤토리 화면을 보여줄 때 실행되는 함수
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
    /// 인벤토리 화면을 끈다
    /// </summary>

    public void OnHide()
    {
        gameObject.SetActive(false);
        // GameManager.UIMode(false);
    }
}
