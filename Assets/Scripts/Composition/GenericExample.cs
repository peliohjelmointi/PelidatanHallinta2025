using UnityEngine;
using UnityEngine.Rendering;

public class GenericExample : MonoBehaviour
{
    [SerializeField] ItemType itemType;

    private void Start()
    {
        PrintValue<int>(42);
        itemType = ItemType.ShortSword;
    }

    void PrintValue<T>(T value)
    {
        print(value);
        print(typeof(T));
    }

}

public enum ItemType
{
    LongSword,
    ShortSword,
    Axe,
    Dart
}



public static class Utils
{
    public static T FindClosest<T>(Vector3 position) where T : Component
    {
        T[] objects = Object.FindObjectsByType<T>(FindObjectsSortMode.None);
        T closest = null;
        float minDist = Mathf.Infinity;

        foreach (T obj in objects)
        {
            float dist = Vector3.Distance(position, obj.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = obj;
            }
        }
        return closest;
    }
}
