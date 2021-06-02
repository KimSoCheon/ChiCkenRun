using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_ScenesMgr : MonoBehaviour
{
    public GameObject hpText;
    public GameObject timeText;
    public GameObject coinText;
    public GameObject gameOverText;
    public int hp;
    public int playTime;
    public int coin;
    void Start()
    {
        hpText = GameObject.Find("HpBar");
        timeText = GameObject.Find("Time");
        coinText = GameObject.Find("CoinText");
        gameOverText = GameObject.Find("GameOver");
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUIInfo();
        if (gameOverText.activeSelf) // GameOver ªÛ»≤....
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void UpdateUIInfo()
    {
        hpText.GetComponent<Slider>().value = (float)hp / 5;
        timeText.GetComponent<Text>().text = "" + playTime;
        coinText.GetComponent<Text>().text = coin.ToString();
    }

    public void GameOverOnOff(bool onOff)
    {
        gameOverText.SetActive(onOff);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameLobby()
    {
        SceneManager.LoadScene(0);
    }
}
