using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    public static NormalItem.eNormalType GetRandomNormalType()
    {
        Array values = Enum.GetValues(typeof(NormalItem.eNormalType));
        NormalItem.eNormalType result = (NormalItem.eNormalType)values.GetValue(URandom.Range(0, values.Length));

        return result;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }

    public static Dictionary<string, List<GameObject>> poolItem = new Dictionary<string, List<GameObject>>();
    public static GameObject InstantiateItem(string prefabName)
    {
        List<GameObject> pool;
        if (!poolItem.ContainsKey(prefabName))
        {
            poolItem.Add(prefabName, pool = new List<GameObject>());
        }
         pool = poolItem[prefabName];
        for(int i = 0; i < pool.Count; ++i)
        {
            if (!pool[i].gameObject.activeSelf)
            {
                return pool[i];
            }
        }
        var instance = GameObject.Instantiate(Resources.Load<GameObject>(prefabName));
        pool.Add(instance);
        return instance;
    }

}
