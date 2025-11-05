using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mc;
    public GameObject targetMap;
    void Start()
    {
        mc = FindFirstObjectByType<MapController>();
        if (mc == null)
            Debug.LogError("⚠️ MapController tidak ditemukan di scene!");
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            mc.CurrentChunk = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            if(mc.CurrentChunk == targetMap)
            {
                mc.CurrentChunk = null;
            }
        }
    }
}
