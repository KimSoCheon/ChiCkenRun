using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Animator toonChicken;
    public float jumpUSpeed = 4f; // ������ ���ǵ�
    public float jumpDSpeed = 5f; // ���� ���ǵ�
    public bool isJump = false; // ���� �� �ʱ�ȭ
    public float jumpLimte = 6f; // ���� Y �� ������ ����
    public bool isSlide = false;
    public bool slideBtnPress = false;
    public float hitCurTime;
    public bool isHit = false;
    public enum JUMPSTATE
    {
        IDLE = 0,
        JUMP,
        DOWN,
        SLIDE,
        HIT
    }
    public float jumpSpeed = 4f;
    public float jumpLimit = 6f;
    public JUMPSTATE jumpState;
    public int jumpCnt = 0;
    public int jumpCntMax = 2;
    public float playerMaxHp = 5f; // �÷��̾� MAX HP
    public int playerHP = 5; // �÷��̾� HP
    public int itemsCnt = 0; // ������ �ʱⰪ COIN
    public int boosterCnt = 0; // �ν��� �ʱⰪ
    public int boosterMax = 10; // �ν��� MAX ��
    public float boosterCurTime = 0f; // �ν��� �ߵ� �ʱⰪ 
    public float boosterCoolTime = 5f; // �ν��� ��Ÿ��
    public bool isBooster = false; // �ν��� �ʱⰪ
    public bool isDead = false; // ����� �ʱⰪ
    public bool isGod; // ���� �ʱⰪ
    public GameSpeedMGR gameSpeedMGR;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        toonChicken = GetComponentInChildren<Animator>();
        gameSpeedMGR = GameObject.Find("GameSpeedMGR").GetComponent<GameSpeedMGR>();
    }

    
    void Update()
    {
        switch (jumpState)
        {
            case JUMPSTATE.IDLE:
                isJump = false;
                isSlide = false;
                transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                jumpCnt = 0;
                jumpLimit = 3f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpState = JUMPSTATE.JUMP;
                    jumpCnt++;
                }
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    jumpState = JUMPSTATE.SLIDE;
                }
                if (slideBtnPress)
                {
                    jumpState = JUMPSTATE.SLIDE;
                }
                break;

            case JUMPSTATE.JUMP:
                isJump = true;
                transform.Translate(0, jumpSpeed * Time.deltaTime, 0);
                if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < jumpCntMax)
                {
                    jumpLimit += transform.position.y;
                    jumpCnt++;
                }
                if (transform.position.y > jumpLimit)
                {
                    jumpState = JUMPSTATE.DOWN;
                    isJump = false;
                }
                break;

            case JUMPSTATE.DOWN:
                transform.Translate(0, -jumpSpeed * Time.deltaTime, 0);
                if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < jumpCntMax)
                {
                    jumpLimit += transform.position.y;
                    jumpCnt++;
                    jumpState = JUMPSTATE.JUMP;
                }
                if (transform.position.y < 0f)
                {
                    jumpState = JUMPSTATE.IDLE;
                }
                break;

            case JUMPSTATE.SLIDE:
                isSlide = true;
                if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                    jumpState = JUMPSTATE.IDLE;
                    isSlide = false;
                }
                if (slideBtnPress == false)
                {
                    jumpState = JUMPSTATE.IDLE;
                    isSlide = false;
                }
                break;

            case JUMPSTATE.HIT:
                isHit = true;
                hitCurTime += Time.deltaTime;
                AnimatorClipInfo[] m_CurrentClipInfo;
                m_CurrentClipInfo = toonChicken.GetCurrentAnimatorClipInfo(0);
                gameSpeedMGR.gameSpeed = 0f;
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                //Debug.Log(m_CurrentClipInfo[0].clip.name);
                //Debug.Log(m_CurrentClipInfo[0].clip.length);
                if (hitCurTime > m_CurrentClipInfo[0].clip.length)
                {
                    isHit = false;
                    hitCurTime = 0;
                    jumpState = JUMPSTATE.IDLE;
                    gameSpeedMGR.gameSpeed = 15f;
                }
                break;

            default:
                break;
        }
        toonChicken.SetBool("ISJUMP", isJump);
        toonChicken.SetBool("ISBOOSTER", isBooster);
        toonChicken.SetBool("ISSLIDE", isSlide);
        toonChicken.SetBool("ISHIT", isHit);
        if (isBooster == true)
        {
            Time.timeScale = 2f;
            boosterCurTime += Time.deltaTime;
            if(boosterCurTime > boosterCoolTime)
            {
                Time.timeScale = 1;
                isBooster = false; // �ʱ�ȭ
                boosterCurTime = 0; // �ʱ�ȭ
                boosterCnt = 0; // �ʱ�ȭ
                isGod = false; // �ʱ�ȭ
            }
        }

        if (isDead == true)
        {
           // Debug.Log("You Died::::");
        }
    }

    public void Jump()
    {
        if (jumpCnt < jumpCntMax)
        {
            jumpLimit += transform.position.y;
            jumpState = JUMPSTATE.JUMP;
            jumpCnt++;
        }
    }

    public void SlidingKeyDown()
    {
        gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 0.25f, 0);
        gameObject.GetComponent<BoxCollider>().size = new Vector3(0.8f, 0.2f, 0.8f);
        slideBtnPress = true;
    }

    public void SlidingKeyUp()
    {
        gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 0.25f, 0);
        gameObject.GetComponent<BoxCollider>().size = new Vector3(0.8f, 0.8f, 0.8f);
        slideBtnPress = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && isGod == false)
        {
            playerHP--;
            jumpState = JUMPSTATE.HIT;
            if(playerHP <= 0)
            {
                isDead = true;
            }
        }
        if(other.gameObject.tag == "Items")
        {
            itemsCnt++;
        }
        if(other.gameObject.name == "HP")
        {
            playerHP++;
            if(playerHP > playerMaxHp)
            {
                playerHP = 5;
            }
        }
        if(other.gameObject.name == "Booster")
        {
            boosterCnt++;
            if(boosterCnt >= 10)
            {
                isBooster = true;
                isGod = true;
            }    
        }
    }
}