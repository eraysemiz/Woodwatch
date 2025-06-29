using UnityEngine;

public class CollectibleResource : MonoBehaviour
{
    public enum ResourceType { Wood, Stone }
    public ResourceType resourceType;
    public int amount = 1;
}
