using System;
using UnityEngine;
using App;

public class Services : MonoBehaviour
{
    public static Services instance;

    private ServiceLocator _services;
    public ServiceLocator services
    {
        get { return _services; }
    }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        _services = new ServiceLocator();
    }

    

}
