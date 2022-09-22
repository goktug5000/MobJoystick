using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsCode : MonoBehaviour
{
    
    public static PlayerStatsCode Instance;
    public int firstTime;
    
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }
    public void save2PlayerPref()
    {
        PlayerPrefs.SetFloat("speedpp", speed);
        PlayerPrefs.SetFloat("maxHPpp", maxHP);
        PlayerPrefs.SetFloat("Armorpp", Armor);

        PlayerPrefs.SetFloat("meleeDmgpp", meleeDmg);

        PlayerPrefs.SetInt("ammoLeftpp", ammoLeft);
        PlayerPrefs.SetFloat("ammoDMGpp", ammoDMG);

        PlayerPrefs.SetInt("myGoldpp", myGold);

        
        firstTime = 0;
        PlayerPrefs.SetInt("firstTime", firstTime);

        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public void LoadFromPlayerPref()
    {
        speed = PlayerPrefs.GetFloat("speedpp");
        maxHP = PlayerPrefs.GetFloat("maxHPpp");
        Armor = PlayerPrefs.GetFloat("Armorpp");

        meleeDmg = PlayerPrefs.GetFloat("meleeDmgpp");

        ammoLeft = PlayerPrefs.GetInt("ammoLeftpp");
        ammoDMG = PlayerPrefs.GetFloat("ammoDMGpp");

        myGold = PlayerPrefs.GetInt("myGoldpp");

        Debug.Log("Loading done!");

        statlarıDagıt();
    }


//PlayerMove.cs
    public float speed=2;
    public float maxHP=10;
    public float Armor=3;
    public int goldInGame;

//PlayerMelee.cs
    public float meleeDmg=5;

//PlayerFire.cs
    public int ammoLeft=30;
    public float ammoDMG=20;


    public int myGold;



    public GameObject StatPanel;
    public Text Speedimiz, maxHPmiz, Armorimiz, meleeDmgmiz, ammoLeftimiz, ammoDMGimiz, myGoldumuz;
    void Start()
    {
        firstTime=PlayerPrefs.GetInt("firstTime");
        /*
        if (firstTime == 1)
        {
            LoadFromPlayerPref();
            Debug.Log("yükledi");
        }
        */

        statlarıDagıt();
        
    }
    public void statlarıDagıt()
    {


        //myGoldumuz.text = myGold.ToString();
        try
        {
            GameObject.Find("ui_manager").GetComponent<uiManager>().statlarıDagıt(speed,  maxHP,  Armor,  meleeDmg,  ammoLeft,  ammoDMG,  myGold);
        }
        catch
        {


        }

    }
    public void anaEkranaGittik()
    {
        myGold += GameObject.Find("Player").GetComponent<PlayerMove>().goldInGame;
    }

    void Update()
    {
        
    }


}
