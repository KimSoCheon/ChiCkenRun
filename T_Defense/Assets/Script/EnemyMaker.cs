using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float curTime;
    public float coolTime = 2f;
    public int enemyCnt = 0;
    public int enemyMaxCnt = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCnt > enemyMaxCnt)
            return;
        
        curTime += Time.deltaTime;
        if(curTime > coolTime)
        {
            curTime = 0;
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            enemyCnt++;
        }
    }
}
