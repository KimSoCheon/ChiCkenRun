using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float deadTime = 5f;
    void Start()
    {
        Destroy(gameObject, deadTime);
        //ªË¡¶
    }

    void Update()
    {
        
    }
}
