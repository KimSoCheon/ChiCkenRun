using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoving_01 : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public void Start()
    {
        
    }
    public void Update()
    {
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }


}