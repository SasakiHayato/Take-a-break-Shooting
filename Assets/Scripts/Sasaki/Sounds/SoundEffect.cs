using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundEffect : MonoBehaviour, IPool
{
    public bool IsUsing { get; set; }

    AudioSource _source;

    public string Name { get; private set; }
    public int ID { get; private set; } = int.MinValue;
    public Action Action { get; private set; }

    SoundData _soundData;

    void Update()
    {
        if (!IsUsing || _source == null) return;

        if (!_source.isPlaying) Action.Invoke();
        else
        {
            float masterVolume = SoundManager.Instance.MasterVolume;
            float volume = 0;
            switch (_soundData.SoundType)
            {
                case SoundType.BGM:
                    masterVolume *= SoundManager.Instance.BGMVolume;
                    volume = masterVolume * _soundData.Volume;
                    break;
                case SoundType.SE:
                    masterVolume *= SoundManager.Instance.SEVolume;
                    volume = masterVolume * _soundData.Volume;
                    break;
            }
            _source.volume = volume;
        }
    }

    public void SetUp()
    {
        gameObject.AddComponent<AudioSource>();
    }

    public void Use(Transform parent, Action action)
    {
        Action = action;
        transform.SetParent(parent);
    }

    public void SetEffectData(SoundData data)
    {
        _soundData = data;
        Name = data.Name;
        ID = data.ID;

        _source = GetComponent<AudioSource>();
        _source.clip = data.Clip;
        _source.spatialBlend = data.SpatialBlend;
        _source.loop = data.Loop;

        float masterVolume = SoundManager.Instance.MasterVolume;
        float volume = 0;
        switch (data.SoundType)
        {
            case SoundType.BGM:
                masterVolume *= SoundManager.Instance.BGMVolume;
                volume = masterVolume * data.Volume;
                break;
            case SoundType.SE:
                masterVolume *= SoundManager.Instance.SEVolume;
                volume = masterVolume * data.Volume;
                break;
        }
        _source.volume = volume;
        _source.Play();
    }

    // Action‚Æ‹¤‚ÉŒÄ‚Î‚ê‚é
    public void Init()
    {
        _source = null;
        _soundData = null;
        Name = null;
        ID = int.MinValue;
    }
}
