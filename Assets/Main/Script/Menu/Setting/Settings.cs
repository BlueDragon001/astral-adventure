using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;




public class Settings : MonoBehaviour
{
    private Slider slider;
    public TMP_Text currentVolume;

    public enum SettingType { masterVolume, musicVolume, SfxVolume }

    public SettingType settingType = new SettingType();

    DataHandler gameDataHandler = new DataHandler();


    void Awake()
    {
        string filePath = gameDataHandler.GetPleyerRefFilePath();
        if (File.Exists(filePath))
        {
            DataHandler.VolumeData volumeData = new DataHandler.VolumeData();
            volumeData = gameDataHandler.LoadRefData();
            staticMenuData.masterVolume = volumeData.masterVolume;
            staticMenuData.musicVolume = volumeData.musicVolume;
            staticMenuData.sfxVolume = volumeData.sfxVolume;

           

            MasterVolumeHandler(true);
            MusicVolumeHandler(true);
            sfxVolumeHandler(true);


        }
        else
        {
            MasterVolumeHandler(false);
            MusicVolumeHandler(false);
            sfxVolumeHandler(false);

          
        }


    }

    public void MasterVolumeHandler(bool hasData)
    {
        if (settingType == SettingType.masterVolume)
        {
            slider = GetComponent<Slider>();

            if (!hasData) staticMenuData.masterVolume = (int)slider.value;
            else slider.value = staticMenuData.masterVolume;


            currentVolume.text = staticMenuData.masterVolume.ToString();
        }

    }

    public void MusicVolumeHandler(bool hasData)
    {
        if (settingType == SettingType.musicVolume)
        {
            slider = GetComponent<Slider>();

            if (!hasData) staticMenuData.musicVolume = (int)slider.value;
            else slider.value = staticMenuData.musicVolume;

            currentVolume.text = staticMenuData.musicVolume.ToString();
        }
    }

    public void sfxVolumeHandler(bool hasData)
    {
        if (settingType == SettingType.SfxVolume)
        {
            slider = GetComponent<Slider>();

            if (!hasData) staticMenuData.sfxVolume = (int)slider.value;
            else slider.value = staticMenuData.sfxVolume;
            currentVolume.text = staticMenuData.sfxVolume.ToString();
        }
    }







    // Update is called once per frame
    void Update()
    {

    }
}
