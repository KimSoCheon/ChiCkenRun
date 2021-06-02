using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHP; //HP ��
    public Text itemsCounter; // COIN TEXT
    public Player_Controller playerController; // �÷��̾� ������Ʈ �ٴ°�
    public Slider boosterGage; // BOOSTER ��
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
        // �÷��̾� HP �� �Ǹ��� ���۳�Ʈ���޸� ���ӿ�����Ʈ playerHP �� ã��.
        playerController = GameObject.Find("Player").GetComponent<Player_Controller>();
        // ��Ʈ�ѷ� ���۳�Ʈ ȣ��
        itemsCounter = GameObject.Find("itemsCounter").GetComponent<Text>();
        // ������ ī���� �ؽ�Ʈ ȣ��
        boosterGage = GameObject.Find("BoosterGage").GetComponent<Slider>();
        //�ν��� ������ �Ǹ��� ȣ��
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        playerHP.value = (float)playerController.playerHP / (float)playerController.playerMaxHp;
        //
        itemsCounter.text = playerController.itemsCnt + "��";
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