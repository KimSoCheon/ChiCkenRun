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
            //��Ʈ��Ʈ (����ü) = ������ �����ھƳ�����
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //var = �ƹ� �ڷ����̳� �� ���������� ����
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider != null)
                    // �΋H�� ���� �ö��̴��� �������������
                {
                    //Debug.Log("�΋H�� ���� �̸� ::::" + hit.collider.gameObject.name);
                    //Debug.Log("�΋H�� ���� ��ġ ::::" +hit.collider.gameObject.transform.position);
                    //Debug.Log("hit.point ::::" + hit.point);
                    box.transform.position = hit.point;
                    //hit.point �� ���� ��ǥ�� ��ġ
                    // ����
                }
            }
        }
    }
}
