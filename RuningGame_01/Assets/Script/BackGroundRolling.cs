using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRolling : MonoBehaviour
{
    public Vector3 originPos;
    public float speed;
    public float limitX;
    public GameSpeedMGR gameSpeedMGR;
    void Start()
    {
        gameSpeedMGR = GameObject.Find("GameSpeedMGR").GetComponent<GameSpeedMGR>();
    }

    void Update()
    {
        speed = gameSpeedMGR.gameSpeed;
        transform.Translate(-speed * Time.deltaTime,0, 0);
        if(transform.position.x < -limitX)
        {
            transform.position = originPos;
        }
    }
}
