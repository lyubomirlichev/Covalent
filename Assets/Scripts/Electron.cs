using UnityEngine;

public class Electron : MonoBehaviour
{
    private Transform nucleusTarget;
    private float orbitSpeed;
    private float orbitDistance;
    
    public void Init(Transform nucleus, float speed, float distance)
    {
        nucleusTarget = nucleus;
        orbitSpeed = speed;
        orbitDistance = distance;
    }

    public void ManualUpdate()
    {
        transform.RotateAround(nucleusTarget.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
