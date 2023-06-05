using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadGame()
    {
        SceneManager.LoadScene(1);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ExitGame();
    }
}
