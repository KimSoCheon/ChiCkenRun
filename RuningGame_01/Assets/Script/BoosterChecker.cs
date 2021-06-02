using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterChecker : MonoBehaviour
{
    public int booster = 0;
    public bool boosterOnOff = false;
    public float curTime;
    public float coolTime;
    public GameObject boosterGage;
    public float boosterSpeed;
    public GameObject boosterEffect;
    public GameObject player;
    public GameObject boosterEffect2;
    void Start()
    {
        //player = GameObject.Find("Player");
        player = gameObject;
    }

    void Update()
    {
        boosterEffect.SetActive(boosterOnOff);
        if (boosterOnOff == true)
        {
            curTime += Time.deltaTime;
            Time.timeScale = 3f;
            player.GetComponent<Player_Controller>().isGod = true;
            //boosterGage.transform.localScale -= new Vector3(boosterSpeed*Time.deltaTime, 0, 0);
            boosterGage.GetComponent<Slider>().value -= boosterSpeed * Time.deltaTime;
            boosterEffect2.SetActive(true);
            boosterEffect2.transform.localScale = new Vector3(Random.Range(4f, 4.5f), Random.Range(4f, 4.5f), Random.Range(4f, 4.5f));
            if (boosterGage.GetComponent<Slider>().value < 0)
            {
                //boosterGage.transform.localScale = new Vector3(0, 1, 1);
                boosterGage.GetComponent<Slider>().value = 0;
                boosterEffect2.transform.localScale = new Vector3(4, 4, 4);
                boosterEffect2.SetActive(false);
            }

            if (curTime > coolTime)
            {
                boosterOnOff = false;
                curTime = 0;
                booster = 0;
                Time.timeScale = 1f;
                boosterGage.GetComponent<Slider>().value = 0;
                player.GetComponent<Player_Controller>().isGod = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Booster"))
        {

            booster++;
            //boosterGage.transform.localScale += new Vector3(0.2f, 0, 0);
            boosterGage.GetComponent<Slider>().value += 0.2f;
            //Debug.Log(boosterGage.transform.position.x);
            if (booster >= 5)
            {
                boosterOnOff = true;
            }
        }
    }
}