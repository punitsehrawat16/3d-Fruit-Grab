using UnityEngine;

public class PlayerZoneDetector : MonoBehaviour
{
    public bool inCollectZone = false;
    public bool inThrowZone = false;
    public bool inTargetZone = false;
    [SerializeField] private TargetSpawner ts;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collect"))
        {
            inCollectZone = true;
        }
        else if (other.CompareTag("Throw"))
        {
            inThrowZone = true;
            ts.SpawnTargets();
        }
        else if (other.CompareTag("Target"))
        {
            inTargetZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collect"))
        {
            inCollectZone = false;
        }
        else if (other.CompareTag("Throw"))
        {
            inThrowZone = false;
            ts.DestroyTargets();
        }
        else if (other.CompareTag("Target"))
        {
            inTargetZone = false;
        }
    }
}