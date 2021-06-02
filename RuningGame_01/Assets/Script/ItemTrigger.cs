using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public GameObject[] itemEffect;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            switch (gameObject.name)
            {
                 case "HP":
                    Instantiate(itemEffect[0], transform.position ,transform.rotation);
                    break;
                 case "Booster":
                     Instantiate(itemEffect[1], transform.position, transform.rotation);
                      break;
                   case "Coin":
                      Instantiate(itemEffect[2], transform.position, transform.rotation);
                      break;
                  default:
                      break;
            }
              Destroy(gameObject);
        }
    }
}