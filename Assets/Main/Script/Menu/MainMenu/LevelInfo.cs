
using UnityEngine;
using System.IO;

public class LevelInfo : MonoBehaviour
{
    public bool isCompleted;
    public bool isCurrentLevel;

    public bool isUnlocked;

    private GameObject currLevel;
    DataHandler dataHandler = new DataHandler();
    DataHandler.LevelData levelData = new DataHandler.LevelData();

    public void OnClick()
    {

        if (gameObject.name == staticLevelData.defaultLevel)
        {
            staticLevelData.currentLevel = gameObject.name;

        }
        else
        {
            foreach (string level in staticLevelData.completedLevel)
            {
                if (gameObject.name == level) staticLevelData.currentLevel = level;
                break;
            }


            int arrayIndex = UnityCSharpExtension.GetArrayIndex(staticLevelData.allLevel, this.gameObject.name);

            if (arrayIndex <= staticLevelData.allLevel.Count)
            {
                foreach (string element in staticLevelData.completedLevel)
                {

                    if (element == staticLevelData.allLevel[arrayIndex - 1])
                    {
                        currLevel = gameObject;
                        break;
                    }
                }

                if (currLevel != null)
                {
                    staticLevelData.currentLevel = currLevel.name;
                }
                else
                {
                    return;
                }
            }

        }

        if (File.Exists(dataHandler.GetLevelFilepath()))
        {
            levelData.completedLevel =  dataHandler.LoadLevelData().completedLevel;
        }
        levelData.currentLevel = staticLevelData.currentLevel;

        dataHandler.SaveLevelData(levelData);
        Debug.Log(dataHandler.GetLevelFilepath());
        Debug.Log(staticLevelData.currentLevel);





    }
}
