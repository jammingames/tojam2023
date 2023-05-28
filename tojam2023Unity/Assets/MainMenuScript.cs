using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public GameObject creditPanel;

    private void Start()
    {
        creditPanel.SetActive(false);
    }
    public void CreditPanel(bool value)
    {
        creditPanel.SetActive(value);
    }
}
