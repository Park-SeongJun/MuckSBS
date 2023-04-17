using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Apple,
    Log,
    Mushroom,
    Stick,
    Stone
}
public class GameManager : MonoBehaviour
{
    public static Inventory inventory;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
