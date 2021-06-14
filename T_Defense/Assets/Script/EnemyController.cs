using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Transform> targetPos;
    public CharacterController characterController;
    public Transform curTargetPos;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            targetPos.Add(GameObject.Find("EnemyNode" + i).transform);
        }
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //if (targetPos[0] == null)
            //return;
        if(targetPos != null)
        {
            curTargetPos = targetPos[0];
            float distance = Vector3.Distance(transform.position, curTargetPos.position);
            Vector3 dir = curTargetPos.position - transform.position;
            dir.y = 0;
            dir.Normalize();
            characterController.SimpleMove(dir * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            //Debug.Log(distance);

            //distance 절대값 - 로 가져올수없음
            if (distance < 0.2f)
            {
                targetPos.RemoveAt(0);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
