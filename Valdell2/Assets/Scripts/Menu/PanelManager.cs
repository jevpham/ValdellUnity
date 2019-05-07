using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject otherPanel;
    public GameObject thisPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            otherPanel.gameObject.SetActive(true);
            thisPanel.gameObject.SetActive(false);
        }      
    }
}
