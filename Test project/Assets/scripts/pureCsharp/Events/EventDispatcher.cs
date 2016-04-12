using System.Collections.Generic;
using App;

public class EventDispatcher :IEventDispatcher {

	private Dictionary<int, List<EventCallback>> callbacksByEventType;

    public EventDispatcher()
    {
        callbacksByEventType = new Dictionary<int, List<EventCallback>>();
    }

    public void addEventListener(AppEvents eventType, EventCallback callback)
    {
       
        List<EventCallback> callbacks;
        int eventNameHash = (int)eventType;

        if (callbacksByEventType.ContainsKey(eventNameHash))
        {
            callbacks = callbacksByEventType[eventNameHash];

        }
        else
        {
            callbacks = new List<EventCallback>();
            callbacksByEventType[eventNameHash] = callbacks;
        }

        if (!callbacks.Contains(callback))
        {
            callbacks.Add(callback);
        }
        
    }


    public void removeEventListener(AppEvents eventType, EventCallback callback)
    {
       
        List<EventCallback> callbacks;

        int eventNameHash = (int)eventType;
        if (callbacksByEventType.ContainsKey(eventNameHash))
        {
            callbacks = callbacksByEventType[eventNameHash];

        }
        else
        {
            return;
        }

        if (callbacks.Contains(callback))
        {
            callbacks.Remove(callback);
        }
    }


    public void dispatchEvent(AppEvents eventType, AbstractEvent eventData)
    {
        List<EventCallback> callbacks;

        int eventNameHash = (int)eventType;
        if (callbacksByEventType.ContainsKey(eventNameHash))
        {
            callbacks = callbacksByEventType[eventNameHash];

        }
        else
        {
            callbacks = new List<EventCallback>();
            callbacksByEventType[eventNameHash] = callbacks;
        }

         
        foreach(EventCallback callback in callbacks)
        {
            callback(eventData);
        }
    }
}
