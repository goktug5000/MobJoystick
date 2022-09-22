using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float hasar, lifeTime, masss;
    void Start()
    {

        this.gameObject.GetComponent<Rigidbody>().mass = masss;
        if (lifeTime == 0)
        {
            lifeTime = 2;
        }
        if (hasar == 0)
        {
            hasar = 1;
        }
    }

    // Update is called once per frameS
    void Update()
    {
        transform.Translate(20 * Time.deltaTime, 0, 0);
        lifeTime = lifeTime - 1 * Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.tag.ToString());
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log(other.gameObject.ToString());
            try
            {
                other.gameObject.GetComponent<CommonEnemy>().EnemyHP -= hasar;
            }
            catch
            {

            }
            try
            {
                other.gameObject.GetComponent<EnemyNest>().EnemyHP -= hasar;
            }
            catch
            {

            }
            Destroy(this.gameObject);
            
        }
    }
}
