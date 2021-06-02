using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items_Maker : MonoBehaviour
{
    public GameObject boosterPrefab;
    public GameObject coinPrefab;
    public GameObject hpPrefab;
    
    public GameObject[] itemPrefabs;
    // 배열로 사용할경우 인덱스 순서를 맞워야 오류가없음.
    
    public float curTime;
    public float coolTime = 2f;
    public int boosterPer;
    public Transform[] itemsPos;

    public GameSpeedMGR gameSpeedMGR;
    public float hitTime = 5f;
    void Start()
    {
        gameSpeedMGR = GameObject.Find("GameSpeedMGR").GetComponent<GameSpeedMGR>();
    }

    void Update()
    {
        if(coolTime >= gameSpeedMGR.gameSpeed)
        {
            curTime = hitTime;
            if (hitTime > gameSpeedMGR.gameSpeed)
            {
                curTime = 0f;
            }
        }
        curTime += Time.deltaTime;
        if (curTime > coolTime)
        {
            RandomPosition();
            int itemsRnd = Random.Range(0, 100);
           
            if (itemsRnd < boosterPer)
            {
                GameObject items = Instantiate(boosterPrefab);
                items.name = "Booster";
                items.transform.position = gameObject.transform.position;
                items.transform.rotation = gameObject.transform.rotation;
            }
            else
            {
                int rndItem = Random.Range(0,10);
                if(rndItem == 1)
                {
                    GameObject items = Instantiate(hpPrefab);
                    items.name = "HP";
                    items.transform.position = gameObject.transform.position;
                    items.transform.rotation = gameObject.transform.rotation;

                }
                else
                {
                    GameObject items = Instantiate(coinPrefab);
                    items.name = "Coin";
                    items.transform.position = gameObject.transform.position;
                    items.transform.rotation = gameObject.transform.rotation;
                }
            }
            curTime = 0;
        }
    }

    void RandomPosition()
    {
        int rnd = Random.Range(0, itemsPos.Length);
        transform.position = itemsPos[rnd].position;
        Debug.Log("rnd ::::" + rnd);
    }
}
