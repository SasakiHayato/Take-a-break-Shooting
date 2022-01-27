using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundGroupID
{
    BGM,
    SE,

    None,
}

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance = null;
    public static SoundManager Instance => _instance;

    [Range(0, 1)] public float MasterVolume;
    [Range(0, 1)] public float BGMVolume;
    [Range(0, 1)] public float SEVolume;
    [SerializeField] SoundEffect _soundEffect;
    [SerializeField] int _poolCount;
    [SerializeField] List<SoundGroup> _soundGroups;

    [System.Serializable]
    class SoundGroup
    {
        public SoundDataBase SoundDataBase;
        public SoundGroupID SoundGroupID;
    }

    ObjectPool<SoundEffect> _soundPool;
    List<SoundEffect> _loopSounds = new List<SoundEffect>();

    void Awake()
    {
        _instance = this;
        _soundPool = new ObjectPool<SoundEffect>(_soundEffect, _poolCount, transform);
    }

    /// <summary>
    /// �炷������Requesut. ���O�Ō���
    /// </summary>
    /// <param name="name">Sound�̖��O</param>
    /// <param name="groupID">GrounpID</param>
    static public void Request(string name, SoundGroupID groupID)
    {
        SoundGroup group = Instance._soundGroups.Find(s => s.SoundGroupID == groupID);
        if (group == null) Debug.Log("Missing. Nothing SoundData");

        SoundData data = group.SoundDataBase.Datas.Find(s => s.Name == name);
        if (data == null) Debug.Log("Missing. Don't MatchName");

        SoundEffect effect = Instance._soundPool
                .UseRequest().GetComponent<SoundEffect>();

        effect.SetEffectData(data);
        if (data.Loop) Instance._loopSounds.Add(effect);
    }

    /// <summary>
    /// �炷������Requesut. ID�Ō���
    /// </summary>
    /// <param name="id">Sound��ID</param>
    /// <param name="groupID">GrounpID</param>
    static public void Request(int id, SoundGroupID groupID)
    {
        SoundGroup group = Instance._soundGroups.Find(s => s.SoundGroupID == groupID);
        if (group == null) Debug.Log("Missing. Nothing SoundData");

        SoundData data = group.SoundDataBase.Datas.Find(s => s.ID == id);
        if (data == null) Debug.Log("Missing. Don't MatchID");

        SoundEffect effect = Instance._soundPool
                .UseRequest().GetComponent<SoundEffect>();

        effect.SetEffectData(data);
        if (data.Loop) Instance._loopSounds.Add(effect);
    }

    /// <summary>
    /// ���ݗ���Ă���Loop�����̍폜. Name�Ō���
    /// </summary>
    /// <param name="name">�폜����SoundName</param>
    static public void DeleteLoopSounds(string name)
    {
        if (Instance._loopSounds.Count <= 0) Debug.Log("Nothing DeleteData");

        SoundEffect effect = Instance._loopSounds.Find(s => s.Name == name);
        effect.Action.Invoke();
    }

    /// <summary>
    /// ���ݗ���Ă���Loop�����̍폜. ID�Ō���
    /// </summary>
    /// <param name="id">�폜����SoundID</param>
    static public void DeleteLoopSounds(int id)
    {
        if (Instance._loopSounds.Count <= 0) Debug.Log("Nothing DeleteData");

        SoundEffect effect = Instance._loopSounds.Find(s => s.ID == id);
        effect.Action.Invoke();
    }
}
