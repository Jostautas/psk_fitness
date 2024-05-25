namespace psk_fitness;

// State management "service"
// Can pass complex objects between views
public class StateContainer
{
    public readonly Dictionary<int, object> ObjectTunnel = new();

    public int PutObject(object obj, int key)
    {
        ObjectTunnel[key] = obj;
        return key;
    }

    public T PopObject<T>(int key)
    {
        T obj = (T) ObjectTunnel[key];
        ObjectTunnel.Remove(key);
        return obj;
    }
}