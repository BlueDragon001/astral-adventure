using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    public GameObject Background;
    public GameObject Panel;
    public TMP_Text menuText;
    void Start()
    {

    }

    public void OnPause()
    {
        menuText.text = "Pause Menu";
        Background.SetActive(true);
        Panel.SetActive(true);
        Time.timeScale = 0;
    }


}
