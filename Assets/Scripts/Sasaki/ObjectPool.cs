using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPool
{
    bool IsUsing { get; set; }
    void SetUp();
    void Use(Transform parent, Action action);
    void Init();
}

public class ObjectPool<PoolType> where PoolType : UnityEngine.Object, IPool
{
    // èâä˙âª
    public ObjectPool(PoolType poolType, int createCount, Transform parent = null)
    {
        _poolType = poolType;
        _createCount = createCount;
        _parent = parent;

        Create();
    }

    List<PoolType> _pool = new List<PoolType>();
    List<PoolType> _usingPool = new List<PoolType>();

    PoolType _poolType;
    int _createCount;
    Transform _parent;

    void Create()
    {
        for (int i = 0; i < _createCount; i++)
        {
            PoolType get = UnityEngine.Object.Instantiate(_poolType, _parent);
            get.IsUsing = false;
            get.SetUp();
            _pool.Add(get);
        }
    }

    /// <summary>
    /// PoolÇ©ÇÁégÇ§ç€Ç…åƒÇ—èoÇ∑ÅB
    /// </summary>
    /// <returns>PoolÇ…ìoò^ÇµÇΩType</returns>
    public PoolType UseRequest()
    {
        PoolType check = _pool.Find(p => !p.IsUsing);
        if (check != null)
        {
            check.IsUsing = true;
            _usingPool.Add(check);
            Action action = null;
            action += Delete;
            action += check.Init;
            check.Use(_parent, action);
            return check;
        }
        else
        {
            Debug.Log("New CreatePool.");
            Create();
            return UseRequest();
        }
    }

    void Delete()
    {
        if (_usingPool.Count <= 0)
        {
            Debug.Log("Nothing UseData");
            return;
        }

        PoolType type = _usingPool.Find(p => !p.IsUsing);
        if (type != null) _usingPool.Remove(type);
    }
}
