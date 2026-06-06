using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditWindow : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject creditMenu;

    public void OnCreditWindow(){
        startMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    public void OnBackClick(){
        startMenu.SetActive(true);
        creditMenu.SetActive(false);
    }
}
