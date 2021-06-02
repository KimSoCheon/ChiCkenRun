using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHP; //HP 바
    public Text itemsCounter; // COIN TEXT
    public Player_Controller playerController; // 플레이어 오브젝트 다는곳
    public Slider boosterGage; // BOOSTER 바
    public GameObject popUpPanel;
    public GameObject panelGameText;
    public Toggle pauseBtn;
    public Slider bgmSlider;
    public AudioSource bgm;
    public GameObject gameOverText;
    public GameObject panelPopUp;
    public GameObject panelGameObject;
    //public GameObject mainBgm;
    void Start()
    {
        panelPopUp.SetActive(false);
        gameOverText.SetActive(false);
        pauseBtn.isOn = false;
        playerHP = GameObject.Find("playerHP").GetComponent<Slider>();
        // 플레이어 HP 는 실린더 컴퍼넌트가달린 게임오브젝트 playerHP 를 찾다.
        playerController = GameObject.Find("Player").GetComponent<Player_Controller>();
        // 컨트롤러 컴퍼넌트 호출
        itemsCounter = GameObject.Find("itemsCounter").GetComponent<Text>();
        // 아이템 카운터 텍스트 호출
        boosterGage = GameObject.Find("BoosterGage").GetComponent<Slider>();
        //부스터 게이지 실린더 호출
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        playerHP.value = (float)playerController.playerHP / (float)playerController.playerMaxHp;
        //
        itemsCounter.text = playerController.itemsCnt + "개";
        boosterGage.value = (float)(playerController.boosterCnt) / (float)(playerController.boosterMax);
        bgm.volume = bgmSlider.value;
        
        if (playerController.playerHP <= 0)
        {
            gameOverText.SetActive(true);
            panelPopUp.SetActive(true);
            panelGameObject.SetActive(false);
            //mainBgm.SetActive(false);
        }
        else
        {
            //mainBgm.SetActive(true);
            panelGameObject.SetActive(true);
        }
    }

    public void PopUpPanelOnOff()
    {
        if(pauseBtn.isOn == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        popUpPanel.SetActive(pauseBtn.isOn);
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