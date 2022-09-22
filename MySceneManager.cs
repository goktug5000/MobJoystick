using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);

    }
    public void AnaEkranaDon()
    {
        SceneManager.LoadScene(0);
        try
        {
            GameObject.Find("PlayerStats").GetComponent<PlayerStatsCode>().anaEkranaGittik();
        }
        catch
        {
            Debug.Log("oyun içi para vergiye gitti");
        }
    }
}
