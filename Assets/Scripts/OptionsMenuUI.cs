using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsMenuUI : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI volumeValue;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        slider.value = audioSource.volume;

        volumeValue.text = ((int)(slider.value * 100)).ToString();
        slider.onValueChanged.AddListener(SetBackgroundVolume);
    }

    public void SetBackgroundVolume(float value)
    {
        volumeValue.text = ((int)(value * 100)).ToString();
        AudioListener.volume = value;
    }
}
