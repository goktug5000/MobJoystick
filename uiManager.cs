using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public GameObject StatPanel;

    bool statPanelB;
    GameObject playerStats;
    public Text Speedimiz, maxHPmiz, Armorimiz, meleeDmgmiz, ammoLeftimiz, ammoDMGimiz, myGoldumuz;


    void Start()
    {
        playerStats=GameObject.Find("PlayerStats");
        StatPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void statPanel()
    {
        statPanelB = !statPanelB;
        StatPanel.SetActive(statPanelB);
        if (statPanelB == true)
        {
            
            playerStats.GetComponent<PlayerStatsCode>().statlarıDagıt();
        }
    }
    public void saveToPlayerStatCode()
    {
        GameObject.Find("PlayerStats").GetComponent<PlayerStatsCode>().save2PlayerPref();
    }
    public void loadFromPlayerStatCode()
    {
        GameObject.Find("PlayerStats").GetComponent<PlayerStatsCode>().LoadFromPlayerPref();
    }
    public void statlarıDagıt(float speedd,float maxHPP,float Armorr,float meleeDmgg,int ammoLeftt,float ammoDMGG,int myGoldd)
    {


        //myGoldumuz.text = myGold.ToString();
        try
        {
            //StatPanel.SetActive(false);
            Speedimiz.text = speedd.ToString();
            maxHPmiz.text = maxHPP.ToString();
            Armorimiz.text = Armorr.ToString();

            meleeDmgmiz.text = meleeDmgg.ToString();

            ammoLeftimiz.text = ammoLeftt.ToString();
            ammoDMGimiz.text = ammoDMGG.ToString();

            myGoldumuz.text = myGoldd.ToString();

            //myGoldumuz.text = myGoldd.ToString();
            Debug.Log("statlar dağıtıldı");
        }
        catch
        {

        }

    }
}
