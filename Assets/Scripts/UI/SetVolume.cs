using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    private int _valueScalar=20;
    [SerializeField] string SliderName;
    [SerializeField] Slider slider;
    private bool result;
    private float value;

    private void Start()
    {
        /*switch (SliderName)
        {
            case "MasterVol":
                result = mixer.GetFloat("MasterVol", out value);
                slider.value = PlayerPrefs.GetFloat("Slider Value");
                break;
            case "MusicVol":

                break;
            case "SFXVol":

                break;
        }*/
    }
    public void SetMasterVolume(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * _valueScalar);
    }
    public void SetMusicVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * _valueScalar);
    }
    public void SetSFXVolume(float sliderValue)
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * _valueScalar);
    }
}
