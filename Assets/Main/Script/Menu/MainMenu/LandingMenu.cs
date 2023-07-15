using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject mainMenu;

    public void OnClickSettings()
    {
        if (!settings.activeSelf)
        {
            settings.SetActive(true);
            mainMenu.SetActive(false);
        }
        else
        {
            settings.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
