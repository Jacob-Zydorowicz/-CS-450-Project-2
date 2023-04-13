using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : Singleton<MusicSingleton>
{
    public AudioSource backgroundMusic;
    protected override void Awake()
    {
        base.Awake();
        backgroundMusic.Play();
        
    }
}
