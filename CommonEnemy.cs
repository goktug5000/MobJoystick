using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = System.Random;

public class CommonEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float EnemySpeed, EnemyMaxHP, EnemyHP, EnemyRegen, EnemyRange;
    public int minGold, maxGold;
    public GameObject WillWalkToward;
    public float distance;
    public TextMeshPro HPmiz;
    public GameObject player;
    public GameObject coin;
    public float EnemyHasar;

    void Start()
    {
        WillWalkToward = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        
        
        if (col.tag == "PlayerDamage")
        {
            Debug.Log("PlayerDamage");
            EnemyHP -=col.gameObject.transform.parent.GetComponent<PlayerMelee>().meleeDmg;
            
        }
        if (col.tag == "Player")
        {
            Debug.Log("Player");
            col.GetComponent<PlayerMove>().myHP -= EnemyHasar*Time.deltaTime;
        }
    }

    void Update()
    {

        transform.LookAt(WillWalkToward.transform);
        distance = Vector3.Distance(this.gameObject.transform.position, WillWalkToward.gameObject.transform.position);
        if (distance > EnemyRange)
        {
            transform.Translate(0, 0, EnemySpeed * Time.deltaTime);
        }




//HP
        HPmiz.text = String.Format("{0:#}", EnemyHP) + " /" + String.Format("{0:##}", EnemyMaxHP);
        //REGEN
        if (EnemyHP < EnemyMaxHP)
        {
            EnemyHP = EnemyHP + EnemyRegen * Time.deltaTime;
        }
        //ÖLMEK
        if (EnemyHP <= 0)
        {
            var newObj = Instantiate(coin, this.gameObject.transform.position, this.gameObject.transform.rotation);

            Random rng = new Random();
            newObj.name = rng.Next(minGold, maxGold + 1).ToString();
            //Debug.Log(newObj.name);
            if (newObj.name == "0")
            {
                Destroy(newObj.gameObject);
            }
            
            Destroy(this.gameObject);
        }

    }

}
