using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderValueText : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (slider.value + 80).ToString();
    }

    public void SetBGM()
    {
        audioMixer.SetFloat("BGM_Volume", slider.value);
    }

    public void SetSE()
    {
        audioMixer.SetFloat("SE_Volume", slider.value);
    }
}
