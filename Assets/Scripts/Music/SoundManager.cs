using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider BGVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;
    public AudioMixer mixer;

    void Start()
    {
        BGVolumeSlider.value = PlayerPrefs.GetFloat("BGMusicVol", 0.3f);
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXMusicVol", 0.5f);
    }

    public void SetBGVolume(float BGVolumeValue)
    {
        mixer.SetFloat("BGMusic", Mathf.Log10(BGVolumeValue) * 20);
        PlayerPrefs.SetFloat("BGMusicVol", BGVolumeValue);
    }

    public void SetSFXVolume(float SFXVolumeValue)
    {
        mixer.SetFloat("SFXMusic", Mathf.Log10(SFXVolumeValue) * 20);
        PlayerPrefs.SetFloat("SFXMusicVol", SFXVolumeValue);
    }



    // void Start()
    // {
    //     if(!PlayerPrefs.HasKey("volume"))
    //     {
    //         PlayerPrefs.SetFloat("volume", 0);
    //         Load();
    //     }

    //     else
    //     {
    //         Load();
    //     }
    // }

    // public void ChangeVolume()
    // {
    //     // mixer.SetFloat("volume", volumeSlider.value);
    //     AudioListener.volume = volumeSlider.value;
    //     Save();
    // }

    // private void Load()
    // {
    //     volumeSlider.value = PlayerPrefs.GetFloat("volume");
    // }

    // private void Save()
    // {
    //     PlayerPrefs.SetFloat("volume", volumeSlider.value);
    // }
}
