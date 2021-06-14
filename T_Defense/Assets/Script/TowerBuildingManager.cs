using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingManager : MonoBehaviour
{
    public GameObject towerPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider.gameObject.tag);
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Block":
                            GameObject tower = Instantiate(towerPrefab) as GameObject;
                            tower.transform.position = hit.collider.transform.position + new Vector3(0, hit.collider.gameObject.transform.localScale.y,0);
                            break;
                        case "BlockNon":
                            Debug.Log("타워를 지을수 없는 곳입니다::::");
                            break;
                    }
                }
            }
        }
    }
}
