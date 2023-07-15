using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource backgroundAudio;
    void Start()
    {
        backgroundAudio = GetComponent<AudioSource>();

        float BGMVolume = UnityCSharpExtension.InterpolateValue(staticMenuData.musicVolume*staticMenuData.masterVolume, 0f, 10000f);
        backgroundAudio.volume = BGMVolume;
     
        backgroundAudio.Play();

        
    }
}
