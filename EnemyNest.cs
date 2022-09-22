using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class EnemyNest : MonoBehaviour
{
    public GameObject Enemy01,coin;
    public float CD;
    public float EnemyMaxHP, EnemyHP, EnemyRegen;
    public int minGold, maxGold;
    public int spawnCD,a;
    public TextMeshPro HPmiz;

    void Start()
    {
        CD = spawnCD;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "PlayerDamage")
        {
            EnemyHP -= col.gameObject.transform.parent.GetComponent<PlayerMelee>().meleeDmg;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.childCount < 5)
        {
            if (CD <= 0)
            {
                spawnEnemy();
                CD = spawnCD;
            }
        }
        if (CD > 0)
        {
            CD -= 1 * Time.deltaTime;
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
            Debug.Log(newObj.name);
            if (newObj.name == "0")
            {
                Destroy(newObj.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    void spawnEnemy()
    {
        var Enemyy = Instantiate(Enemy01, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Enemyy.transform.parent = this.gameObject.transform;
    }

}
