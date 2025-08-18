using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SfxSetup> sfxSetups;

    public AudioSource musicSource;

    public void PlayeMusicByType(MusicType musicType)
    {
      var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
       return musicSetups.Find(i => i.musicType == musicType);
    }

    public SfxSetup GetSfxByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxType == sfxType);
    }
}

public enum MusicType
{
    TYPE_01,
    TYPE_02,
    TÝPE_03
}

[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;
}

public enum SFXType
{
    NONE,
    TYPE_01,
    TYPE_02,
    TÝPE_03
}

[System.Serializable]
public class SfxSetup
{
    public SFXType sfxType;
    public AudioClip audioClip;
}