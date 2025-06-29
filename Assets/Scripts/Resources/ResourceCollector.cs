using System.Resources;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    public float collectRange = 2f;
    public KeyCode collectKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(collectKey))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, collectRange);

            foreach (Collider hit in hits)
            {
                CollectibleResource res = hit.GetComponent<CollectibleResource>();
                if (res != null)
                {
                    ResourceManager.Instance.AddResource(res.resourceType.ToString(), res.amount);
                    Destroy(hit.gameObject); // Kaynaðý yok et
                    break; // Tek kaynaðý topla
                }
            }
        }
    }
}
