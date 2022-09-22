using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mermi;
    public Text ammoLeftText;
    public int ammoLeft;
    public float ammoDMG;
    public void loadMyData()
    {
        try
        {
            ammoLeft = PlayerStatsCode.Instance.ammoLeft;
            ammoDMG = PlayerStatsCode.Instance.ammoDMG;
        }
        catch
        {

        }
    }

    void Start()
    {
        loadMyData();
        ammoLeftText.text = ammoLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire()//FLOATING JOYSTICKTEN GELİYOR
    {
        if (ammoLeft > 0)
        {
            ammoLeft--;
            ammoLeftText.text = ammoLeft.ToString();
            doingFire();
        }
    }

    void doingFire()
    {
        var mermii = Instantiate(mermi, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
