using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public event Action OnResourceChanged; // Olay tanýmý

    private Dictionary<string, int> resources = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddResource(string type, int amount)
    {
        if (!resources.ContainsKey(type))
            resources[type] = 0;

        resources[type] += amount;

        Debug.Log($"{type} +{amount} (Toplam: {resources[type]})");

        OnResourceChanged?.Invoke(); // UI'ya haber ver
    }

    public int GetResource(string type)
    {
        return resources.ContainsKey(type) ? resources[type] : 0;
    }

    // Eðer kaynak harcama sistemin olacaksa:
    public bool TrySpendResource(string type, int amount)
    {
        if (resources.ContainsKey(type) && resources[type] >= amount)
        {
            resources[type] -= amount;
            OnResourceChanged?.Invoke(); // UI'yý yine bilgilendir
            return true;
        }
        return false;
    }
}
