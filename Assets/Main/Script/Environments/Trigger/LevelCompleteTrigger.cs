using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class LevelCompleteTrigger : MonoBehaviour
{

    DataHandler dataHandler = new DataHandler();
    DataHandler.LevelData levelData = new DataHandler.LevelData();
    public GameObject player,panel,backgroundPanel,levelNext,resume;
    public TMP_Text menuTitle,nextLevelText;

    void Start()
    {
        levelData = dataHandler.LoadLevelData();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(staticString.playerTag))
        {
            StartCoroutine(OnLevelComplete(1));

            staticLevelData.completedLevel.Add(staticLevelData.currentLevel);
            levelData.completedLevel = staticLevelData.completedLevel;
            int arrayIndex = UnityCSharpExtension.GetArrayIndex(staticLevelData.allLevel, SceneManager.GetActiveScene().name);
            if (arrayIndex != staticLevelData.allLevel.Count)
            {
                staticLevelData.currentLevel = staticLevelData.allLevel[arrayIndex + 1];

            }
            else
            {
                staticLevelData.currentLevel = staticLevelData.allLevel[arrayIndex];
            }

            levelData.currentLevel = staticLevelData.currentLevel;
            dataHandler.SaveLevelData(levelData);
        }
    }

    IEnumerator OnLevelComplete(float seconds){
        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        yield return new WaitForSeconds(seconds);
        menuTitle.text = "Level Completed";
        playerManager.inputEnabled = false;
        panel.SetActive(true);
        backgroundPanel.SetActive(true);
        levelNext.SetActive(true);
        resume.SetActive(false);
        nextLevelText.text = "Play " + staticLevelData.currentLevel;
    }

  

    
}
