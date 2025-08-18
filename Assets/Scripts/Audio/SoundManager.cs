using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<MusicSetup> musicSetups;
    public List<SfxSetup> sfxSetups;
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

public enum SfxType
{
    TYPE_01,
    TYPE_02,
    TÝPE_03
}

[System.Serializable]
public class SfxSetup
{
    public SfxType sfxType;
    public AudioClip audioClip;
}