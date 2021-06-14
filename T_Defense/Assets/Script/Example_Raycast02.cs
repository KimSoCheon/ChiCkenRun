using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Raycast02 : MonoBehaviour
{
    public GameObject hitEffect_Dirt;
    public GameObject hitEffect_Metal;
    public GameObject hitEffect_Wood;
    public AudioClip dirtSound;
    public AudioClip metalSound;
    public AudioClip woodSound;
    public SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

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
                    switch (hit.collider.gameObject.name)
                    {
                        case "Well_Dirt":
                            Instantiate(hitEffect_Dirt, hit.point,Quaternion.Euler(-180f,0,0));
                            soundManager.PlaySfx(dirtSound);
                            break;
                        case "Well_Metal":
                            Instantiate(hitEffect_Metal, hit.point, Quaternion.Euler(-180f, 0, 0));
                            soundManager.PlaySfx(metalSound);
                            break;
                        case "Well_Wood":
                            Instantiate(hitEffect_Wood, hit.point, Quaternion.Euler(-180f, 0, 0));
                            soundManager.PlaySfx(woodSound);
                            break;
                        
                        default:
                            break;
                    }
                }
            }
        }
    }
}
