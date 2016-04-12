

public class ServiceLocator {

    private IEventDispatcher _dispatcher;
    public IEventDispatcher dispatcher
    {
        get { return _dispatcher; }
    }

    public ServiceLocator()
    {
        _dispatcher = new EventDispatcher();
    }
}
