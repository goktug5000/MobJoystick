using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    // Start is called before the first frame update
    public float meleeDmg;
    private float cd;
    public GameObject sword;

    public void loadMyData()
    {
        try
        {
            meleeDmg = PlayerStatsCode.Instance.meleeDmg;
        }
        catch
        {

        }
    }

    void Start()
    {
        sword.SetActive(false);
        loadMyData();
    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)
        {
            cd = cd - 1 * Time.deltaTime;
        }

        
    }
    public void Melee()
    {
        if (cd <= 0)
        {
            StartCoroutine(doMelee());
            //Debug.Log("Melee yaptın    PlayerMelee.cs");
        }


    }
    IEnumerator doMelee()
    {
        cd = 0.7f;
        //Debug.Log("DİLDO");
        //sword.transform.LookAt(GetClosestEnemy());
        sword.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        sword.SetActive(false);

    }
    /*
    public Transform GetClosestEnemy()
    {
        Transform yakınKonum = null;
        try
        {
            float minDist = Mathf.Infinity;
            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                float dist = Vector3.Distance(this.gameObject.transform.position, enemy.transform.position);
                if (dist < minDist)
                {
                    yakınKonum = enemy.transform;
                    minDist = dist;
                }
            }
        }
        catch
        {

        }
        return yakınKonum;
    }
    */

}
