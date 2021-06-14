using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Raycast : MonoBehaviour
{
    public GameObject box;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            //스트럭트 (구조체) = 변수만 때려박아놓은애
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //var = 아무 자료형이나 다 때려박을수 있음
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider != null)
                    // 부딫힌 애의 컬라이더가 비어있지않으면
                {
                    //Debug.Log("부딫힌 애의 이름 ::::" + hit.collider.gameObject.name);
                    //Debug.Log("부딫힌 애의 위치 ::::" +hit.collider.gameObject.transform.position);
                    //Debug.Log("hit.point ::::" + hit.point);
                    box.transform.position = hit.point;
                    //hit.point 는 월드 좌표의 위치
                    // 실행
                }
            }
        }
    }
}
