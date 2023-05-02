using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public int needUpgradeCount;
    public float HP { get; set; }
    public int level;
    public int maxHP;

    public int Level {
        get { return level; }
        set
        {
            level = value;
            if(level != 0)
            {
                if (level < FenceManager.Instance.meshs.Length - 1)
                {
                    if (GameManager.inventory.DeleteItem("�볪��", needUpgradeCount))
                    {
                        GetComponent<MeshFilter>().mesh = FenceManager.Instance.meshs[level];
                        HP = maxHP + (maxHP * level);
                        needUpgradeCount = (level + 1) + (transform.parent.GetComponent<FenceObj>().needCount * level);
                        UI.Instance.ToastPopup($"{level + 1}�� ���׷��̵� �Ϸ�. ");
                    }
                    else
                    {
                        UI.Instance.ToastPopup($"���׷��̵尡 �ִ�ġ �Դϴ�.");
                    }
                }               
                else
                {
                    UI.Instance.ToastPopup($"��ᰡ �����մϴ�");
                }
            }           
        }
    }

    void Start()
    {
        maxHP = 10;
        Level = 0;
        needUpgradeCount = (level + 1) + (transform.parent.GetComponent<FenceObj>().needCount * level);
    }

    public void Hit(float dmg)
    {
        HP -= dmg;

        if(HP <= 0)
        {
            Hide();
            transform.parent.GetComponent<FenceObj>().Show();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
