using UnityEngine;

public class CommonEvent : AbstractEvent
{

    private Transform _eventSource;

    public Transform eventSource
    {
        get { return _eventSource; }
    }

    public CommonEvent(Transform eventSource)
    {
        _eventSource = eventSource;
    }
}
