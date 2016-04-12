using App;


public interface IEventDispatcher {
    void addEventListener(AppEvents eventType, EventCallback callback);

    void removeEventListener(AppEvents eventType, EventCallback callback);

    void dispatchEvent(AppEvents eventType, AbstractEvent eventData);

}
