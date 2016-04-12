using UnityEngine;
using System.Collections;
using App;

public class TestEvents : MonoBehaviour {


    public Button btn1;
    public Button btn2;

    private IEventDispatcher dispatcher;

    private bool clickEnabled = false;
    // Use this for initialization
    void Start () {

        dispatcher = Services.instance.services.dispatcher;

        btn1.addEventListener(AppEvents.TRIGGERED, new EventCallback(onBtn1));
        btn2.addEventListener(AppEvents.TRIGGERED, new EventCallback(onBtn2));
    }
    

    private void onBtn1(AbstractEvent data)
    {
        /*CommonEvent eventData = data as CommonEvent;

        if (eventData.eventSource == clickController)
        {
            Debug.Log("here 2");
            clickEnabled = !clickEnabled;
            if (clickEnabled)
            {
                dispatcher.addEventListener(AppEvents.TRIGGERED, new EventCallback(callback));
            } else
            {
                dispatcher.removeEventListener(AppEvents.TRIGGERED, new EventCallback(callback));
            }
        }*/

      
        Debug.Log("Clck btn 1");
    }

    private void onBtn2(AbstractEvent data)
    {
        /*CommonEvent eventData = data as CommonEvent;

        if (eventData.eventSource == clickController)
        {
            Debug.Log("here 2");
            clickEnabled = !clickEnabled;
            if (clickEnabled)
            {
                dispatcher.addEventListener(AppEvents.TRIGGERED, new EventCallback(callback));
            }
            else
            {
                dispatcher.removeEventListener(AppEvents.TRIGGERED, new EventCallback(callback));
            }
        }*/

        
        Debug.Log("Clck btn 2");
        
    }

    // Update is called once per frame
    void Update () {
	
	}
}
