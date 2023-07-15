using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DeathMenu : MonoBehaviour
{
    public GameObject player;
    private PlayerManager playerManager;
    public GameObject panel;
    public GameObject backgroundPanel;
    public GameObject resumeButton;
    public TMP_Text menuText;

    void Start()
    {
        playerManager = player.GetComponent<PlayerManager>();
        playerManager.PlayerDeath += OnPlayerDeath;
    }

    void OnPlayerDeath()
    {
        StartCoroutine(OnPlayerDeath(2));
    }

    IEnumerator OnPlayerDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        menuText.text = "Game Over";
        panel.SetActive(true);
        backgroundPanel.SetActive(true);
        resumeButton.SetActive(false);
    }



}
