using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    public GameObject[] allLevel;

    DataHandler dataHandler = new DataHandler();
    DataHandler.LevelData levelData = new DataHandler.LevelData();


    void Start()
    {
        staticLevelData.allLevel = allLevel.ToList().ConvertAll(gameObj => gameObj.name);
        if (File.Exists(dataHandler.GetLevelFilepath()))
        {
            levelData = dataHandler.LoadLevelData();
            staticLevelData.currentLevel = GameObject.Find(levelData.currentLevel).name;
            staticLevelData.completedLevel = levelData.completedLevel;
            foreach (string level in levelData.completedLevel)
            {
                GameObject levelObject = GameObject.Find(level);
                Image image = levelObject.GetComponent<Image>();
                Material material = image.material;
                material.SetInt(staticString.isGrayscale, 0);
            }

        }
        if (File.Exists(dataHandler.GetPleyerRefFilePath()))
        {
            DataHandler.VolumeData volumeData = new DataHandler.VolumeData();
            volumeData = dataHandler.LoadRefData();
            staticMenuData.masterVolume = volumeData.masterVolume;
            staticMenuData.sfxVolume = volumeData.sfxVolume;
            staticMenuData.musicVolume = volumeData.musicVolume;
        }
        if (staticLevelData.currentLevel == null)
        {
            staticLevelData.currentLevel = GameObject.Find(staticLevelData.defaultLevel).name;

        }


    }

    public void OnPlay()
    {

        //     staticLevelData.allLevel = allLevel.ToList();



        //     staticLevelData.completedLevel.Add(staticLevelData.currentLevel);
        //     if (File.Exists(dataHandler.GetLevelFilepath()))
        //     {
        //         levelData.currentLevel = dataHandler.LoadLevelData().currentLevel;
        //     }
        // //    if(levelData.completedLevel)
        //     dataHandler.SaveLevelData(levelData);
        Debug.Log(staticLevelData.currentLevel);

        SceneManager.LoadScene(staticLevelData.currentLevel);

    }


    // Update is called once per frame
    void Update()
    {
        GameObject levelObject = GameObject.Find(staticLevelData.currentLevel);
        Image image = levelObject.GetComponent<Image>();
        Material material = image.material;
        material.SetInt(staticString.isGrayscale, 0);
    }
}

// using UnityEngine;
// using UnityEngine.SceneManagement;
// using System.Linq;
// using System.IO;


// public class LevelLoader : MonoBehaviour
// {
//     public GameObject[] allLevel;
//     public GameObject defaultLevel;
//     DataHandler dataHandler = new DataHandler();
//     DataHandler.LevelData levelData = new DataHandler.LevelData();


//     void Start()
//     {
//         staticLevelData.allLevel = allLevel.ToList();
//         if (File.Exists(dataHandler.GetLevelFilepath()))
//         {
//             levelData = dataHandler.LoadLevelData();
//             staticLevelData.currentLevel = GameObject.Find(levelData.currentLevel);
//             staticLevelData.completedLevel = levelData.completedLevel.ConvertAll(str => GameObject.Find(str));

//         }
//         if(File.Exists(dataHandler.GetPleyerRefFilePath())){
//             DataHandler.VolumeData volumeData = new DataHandler.VolumeData();
//             volumeData = dataHandler.LoadRefData();
//             staticMenuData.masterVolume = volumeData.masterVolume;
//             staticMenuData.sfxVolume = volumeData.sfxVolume;
//             staticMenuData.musicVolume = volumeData.musicVolume;
//         }
//     }

//     public void OnPlay()
//     {

//         staticLevelData.allLevel = allLevel.ToList();
//         if (staticLevelData.currentLevel == null)
//         {
//             staticLevelData.currentLevel = defaultLevel;
//         }



//         staticLevelData.completedLevel.Add(staticLevelData.currentLevel);
//         if (File.Exists(dataHandler.GetLevelFilepath()))
//         {
//             levelData.currentLevel = dataHandler.LoadLevelData().currentLevel;
//         }
//         levelData.completedLevel = staticLevelData.completedLevel.ConvertAll(gameObj => gameObj.name);
//         dataHandler.SaveLevelData(levelData);
//         Debug.Log(staticLevelData.currentLevel);

//         SceneManager.LoadScene(staticLevelData.currentLevel.name);

//     }


//     // Update is called once per frame
//     void Update()
//     {

//     }
// }

