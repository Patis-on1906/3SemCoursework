namespace Coursework.Backend;

public static class CollectionExtensions
{
    public static void AddUnique<T>(this List<T> list, T item,
        string itemName, string containerName)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        
        if (list.Contains(item))
            throw new InvalidOperationException($"{itemName} уже есть в {containerName}");
        
        list.Add(item);
    }
}