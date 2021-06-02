using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Maker : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public float curTime;
    public float coolTime = 2f;
    public GameSpeedMGR gameSpeedMGR;
    public float hitTime = 4f;
    void Start()
    {
        gameSpeedMGR = GameObject.Find("GameSpeedMGR").GetComponent<GameSpeedMGR>();
    }

    void Update()
    {
        if (coolTime >= gameSpeedMGR.gameSpeed)
        {
            curTime = hitTime;
            if (hitTime > gameSpeedMGR.gameSpeed)
            {
                curTime = 0;
            }
        }
        curTime += Time.deltaTime;
        if(curTime > coolTime)
        {
            GameObject enemy = Instantiate(enemyPrefabs);
            enemy.transform.position = gameObject.transform.position;
            enemy.transform.rotation = gameObject.transform.rotation;
            curTime = 0;
            RandomCoolTime();
        }
    }

    void RandomCoolTime()
    {
        coolTime = Random.Range(1, 6);
    }
}
