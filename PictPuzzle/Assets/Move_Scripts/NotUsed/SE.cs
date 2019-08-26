using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip Cursor;
    public AudioClip Landing;
    public AudioClip Block;
    public AudioClip Select;
    public AudioClip Cry;
    public AudioClip GameOver;
    public AudioClip GameClear;

    AudioSource Audio;
     void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
}
