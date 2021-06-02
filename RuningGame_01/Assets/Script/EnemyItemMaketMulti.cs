using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyItemMaketMulti : MonoBehaviour
{
    public float curTime;
    public float coolTime;
    public GameObject[] enemyPrefabs;
    public GameObject[] items;
    void Start()
    {
        
    }

    void Update()
    {
        curTime += Time.deltaTime;

        if (curTime > coolTime)
        {
            int lotto = Random.Range(0, 100);
            if (lotto > 25)
            {
                MakeEnemy();
            }
            else
            {
                MakeItem();
            }
            curTime = 0;
        }
    }

    public void MakeEnemy()
    {
        int rnd = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[rnd], transform.position, transform.rotation);
    }

    public void MakeItem()
    {
        int rnd = Random.Range(0, items.Length);
        Instantiate(items[rnd], transform.position, transform.rotation);
    }
}
