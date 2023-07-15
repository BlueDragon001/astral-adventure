using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDataLoader : MonoBehaviour
{
    DataHandler gameDataHandler = new DataHandler();
    void Start()
    {
        DataHandler dataHandler = new DataHandler();
        DataHandler.VolumeData volumeData = dataHandler.LoadRefData();

        staticMenuData.masterVolume = volumeData.masterVolume;
        staticMenuData.musicVolume = volumeData.musicVolume;
        staticMenuData.sfxVolume = volumeData.sfxVolume;
    }

    public void SaveData()
    {

        DataHandler.VolumeData volumeData = new DataHandler.VolumeData();
        volumeData.masterVolume = staticMenuData.masterVolume;
        volumeData.musicVolume = staticMenuData.musicVolume;
        volumeData.sfxVolume = staticMenuData.sfxVolume;

      

        gameDataHandler.SavePlayerRefData(volumeData);


    }
}
