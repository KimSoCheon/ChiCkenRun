using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float enemySpeed = 5f;
    public GameSpeedMGR gameSpeedMGR;
    void Start()
    {
        gameSpeedMGR = GameObject.Find("GameSpeedMGR").GetComponent<GameSpeedMGR>();
    }

    void Update()
    {
        enemySpeed = gameSpeedMGR.gameSpeed;
        transform.Translate(-enemySpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + ":::: 에 맞았다 ::::");
        Destroy(gameObject);
    }
}
