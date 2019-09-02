using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    private Text BGM_text;
    [SerializeField]
    private Text SE_text;
    [SerializeField]
    private Slider BGM_slider;
    [SerializeField]
    private Slider SE_slider;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        BGM_slider.value = StageFlags.instance.BGM_VolumeGet();
        SE_slider.value = StageFlags.instance.SE_VolumeGet();
        audioMixer.SetFloat("BGM_Volume", BGM_slider.value);
        audioMixer.SetFloat("SE_Volume", SE_slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        BGM_text.text = (BGM_slider.value + 80).ToString();
        SE_text.text = (SE_slider.value + 80).ToString();
    }

    public void SetBGM()
    {
        StageFlags.instance.BGM_VolumeSet((int)BGM_slider.value);
        audioMixer.SetFloat("BGM_Volume", StageFlags.instance.BGM_VolumeGet());
    }

    public void SetSE()
    {
        StageFlags.instance.SE_VolumeSet((int)SE_slider.value);
        audioMixer.SetFloat("SE_Volume", StageFlags.instance.SE_VolumeGet());
    }

    public void TitleBack_Option()
    {
        StageFlags.instance.BGM_VolumeSet((int)BGM_slider.value);
        StageFlags.instance.SE_VolumeSet((int)SE_slider.value);
        StageFlags.instance.FileSave();

        StageFlags.instance.AudioPlay(audioClip);
        StageFlags.instance.StartCoroutine("Load", "Title");
    }
}