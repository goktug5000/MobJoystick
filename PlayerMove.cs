using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody myBody;
    private DynamicJoystick joystickDynamic;
    private FloatingJoystick joystickFloatin;
    public GameObject mainPlayer, go2FirstScene,silah;
    public TextMeshPro HPmiz;
    public float myY,myGunY, speed, myHP, maxHP, Armor;
    public int goldInGame;
    public Text goldInGameimiz;

    public void loadMyData()
    {
        try
        {
            maxHP = PlayerStatsCode.Instance.maxHP;
            speed = PlayerStatsCode.Instance.speed;
            Armor = PlayerStatsCode.Instance.Armor;
        }
        catch
        {

        }
    }

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        joystickDynamic = GameObject.Find("Dynamic Joystick").GetComponent<DynamicJoystick>();
        joystickFloatin = GameObject.Find("Floating Joystick").GetComponent<FloatingJoystick>();

        go2FirstScene.SetActive(false);

        loadMyData();
        myHP = maxHP;

        goldInGame = 0;
        goldInGameimiz.text = goldInGame.ToString();

        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Gold")
        {
            goldInGame += Int32.Parse(col.gameObject.name);
            goldInGameimiz.text = goldInGame.ToString();
            Destroy(col.gameObject);

        }
    }

    void Update()
    {
        //Debug.Log((Math.Atan2(joystick.Vertical, joystick.Horizontal) * 57.2958).ToString());



//YÜRÜMEK İÇİN
        if (joystickDynamic.Vertical != 0 && joystickDynamic.Horizontal != 0)
        {
            speed = Convert.ToSingle(Math.Sqrt(joystickDynamic.Vertical * joystickDynamic.Vertical + joystickDynamic.Horizontal * joystickDynamic.Horizontal));
        }
        if (joystickDynamic.Vertical != 0 && joystickDynamic.Horizontal != 0)
        {
            mainPlayer.transform.Translate(speed*10 * Time.deltaTime, 0, 0);
        }

//YÖN İÇİN
        if (joystickDynamic.Vertical != 0 && joystickDynamic.Horizontal != 0 && joystickFloatin.BasiliMiyim == false)
        {
            myY = Convert.ToSingle(Math.Atan2(joystickDynamic.Vertical, joystickDynamic.Horizontal) * 57.2958);
        }
        if (joystickFloatin.BasiliMiyim == true)
        {
            float buyukluk = Convert.ToSingle(Math.Sqrt(joystickFloatin.Vertical * joystickFloatin.Vertical + joystickFloatin.Horizontal * joystickFloatin.Horizontal));
            if (buyukluk > 0.3)
            {
                myGunY = Convert.ToSingle(Math.Atan2(joystickFloatin.Vertical, joystickFloatin.Horizontal) * 57.2958);
            }
            
        }
        mainPlayer.transform.rotation = Quaternion.Euler(0, -myY, 0);
        silah.transform.rotation = Quaternion.Euler(0, -myGunY, 0);

        //HP
        HPmiz.text= String.Format("{0:#}", myHP) + " /" + String.Format("{0:##}", maxHP);
        //REGEN
        if (myHP  < maxHP)
        {
            myHP = myHP + 1 * Time.deltaTime;
        }
//ÖLMEK
        if (myHP <= 0)
        {
            Time.timeScale = 0;

            go2FirstScene.SetActive(true);
            
        }


        
    }

    public void saveMyData()
    {
        PlayerStatsCode.Instance.goldInGame = goldInGame;
    }

}
