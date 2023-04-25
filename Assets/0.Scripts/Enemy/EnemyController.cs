using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Transform parent;

    int spawnCnt = 0;
    int spawnMaxCnt = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnStart");
    }

    public IEnumerator SpawnStart()
    {
        for (int i = 0; i < spawnMaxCnt; i++)
        {
            Instantiate(enemies[0], parent);
            yield return new WaitForSeconds(3f);
        }
    }
}
