using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Background;
    public GameObject Panel;
    void Start()
    {

    }
    public void OnResume()
    {
        Background.SetActive(false);
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnReplay()
    {
        Time.timeScale = 1;
        Background.SetActive(false);
        Panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        
    }
}
