using UnityEngine;

public class PortalControl : MonoBehaviour
{
    [SerializeField] TextControl tC;
    [SerializeField] GameObject portal;

    GameObject portalSpawned;

    public void spawnPortal()
    {
        // Optional: Convert from screen to world position if needed
        Vector3 screenPos = new Vector3(tC.pos.x, tC.pos.y, 10f); // 10 = Z distance from camera
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        if (portalSpawned != null)
        {
            Destroy(portalSpawned);
        }

        portalSpawned = Instantiate(portal, worldPos, portal.transform.rotation);
    }

    public void despawnPortal()
    {
        if (portalSpawned != null)
        {
            Destroy(portalSpawned);
            portalSpawned = null;
        }
    }
}
