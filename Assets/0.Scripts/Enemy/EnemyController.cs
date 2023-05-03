using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Transform parent;

    [SerializeField] private BoxCollider spawnBox;
    [SerializeField] private Sun sun;

    int spawnCnt = 0;
    int spawnMaxCnt = 10;
    bool isSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        float x = sun.transform.eulerAngles.x;
        if (!isSpawn && (x > 60 && x < 61))
        {
            isSpawn = true;
            StartCoroutine("SpawnStart");
        }
    }
    public IEnumerator SpawnStart()
    {
        for (int i = 0; i < spawnMaxCnt; i++)
        {
            Enemy e = Instantiate(enemies[0], parent);
            e.transform.localPosition = RandomPosition();
            yield return new WaitForSeconds(3f);
        }
        isSpawn = false;
    }

    Vector3 RandomPosition()
    {
        Vector3 originPos = spawnBox.transform.localPosition;

        Bounds b = spawnBox.bounds;
        Vector2 size = new Vector2(b.size.x, b.size.z);

        size.x = Random.Range((size.x / 2) * -1, size.x / 2);
        size.y = Random.Range((size.y / 2) * -1, size.y / 2);

        return originPos + new Vector3(size.x, 0f, size.y);
    }
}
