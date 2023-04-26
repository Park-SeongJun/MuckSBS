using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : Singleton<JsonData>
{
    [System.Serializable]
    public struct TData
    {
        public int att;
        public int hp;
        public int attdis;
        public float attdelay;
    }
    [System.Serializable]
    public struct TurretData
    {
        public List<TData> turret;
    }

    [SerializeField] TextAsset turretJson;

    [HideInInspector] public TurretData tData;

    // Start is called before the first frame update
    void Start()
    {
        tData = JsonUtility.FromJson<TurretData>(turretJson.text);
    }
}
