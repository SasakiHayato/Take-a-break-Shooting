using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    BGM,
    SE,
}

[CreateAssetMenu (fileName = "SoundDatas")]
public class SoundDataBase : ScriptableObject
{
    public List<SoundData> Datas = new List<SoundData>();
}

[System.Serializable]
public class SoundData
{
    public string Name;
    public int ID;
    public SoundType SoundType;
    public AudioClip Clip;
    [Range(0, 1)] public float Volume;
    [Range(0, 1)] public float SpatialBlend;
    public bool Loop;
}
