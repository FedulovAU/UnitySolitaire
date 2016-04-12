using UnityEngine;
using App;

public class ExtendedMono : MonoBehaviour, IEventDispatcher {

    protected EventDispatcher _dispatcher;

    void Awake()
    {
        _dispatcher = new EventDispatcher();
    }

 

    public void dispatchEvent(AppEvents eventType, AbstractEvent eventData = null)
    {
        _dispatcher.dispatchEvent(eventType, eventData);
    }

    public void addEventListener( AppEvents eventType, EventCallback callback)
    {
        _dispatcher.addEventListener(eventType, callback);
    }

    public void removeEventListener(AppEvents eventType, EventCallback callback)
    {
        _dispatcher.removeEventListener(eventType, callback);
    }

}
