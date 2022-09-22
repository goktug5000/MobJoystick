using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuPanel;
    bool menuB;
    void Start()
    {
        menuB = false;

        menuPanel.SetActive(menuB);
    }

    public void menuOpen()
    {
        menuB = !menuB;
        menuPanel.SetActive(menuB);
        if (menuB)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
