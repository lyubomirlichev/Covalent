using UnityEngine;

public class Electron : MonoBehaviour
{
    private Transform nucleusTarget;
    private float orbitSpeed;
    private float orbitDirection;

    public void Init(Transform nucleus, float speed, float direction)
    {
        nucleusTarget = nucleus;
        orbitSpeed = speed;
        orbitDirection = direction;
    }

    public void ManualUpdate(float timeStep)
    {
        transform.RotateAround(nucleusTarget.transform.position, Vector3.up,  orbitDirection * orbitSpeed * timeStep);
    }
}