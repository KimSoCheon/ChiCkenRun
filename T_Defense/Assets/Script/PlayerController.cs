using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 dir;
    public Transform target;
    public CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.LookAt(target);
        dir = transform.localRotation.eulerAngles;
        dir.x = 0;
        transform.localRotation = Quaternion.Euler(dir);
        // 위 아래 고정
    }
}
