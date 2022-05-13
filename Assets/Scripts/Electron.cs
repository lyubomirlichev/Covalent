using UnityEngine;

//not needed for now
public class Electron : MonoBehaviour
{
    private Transform nucleusTarget;
    private float orbitSpeed;
    private float orbitDirection;

    private Vector3 velocity;
    public void Init(Transform nucleus, float speed, float direction)
    {
        nucleusTarget = nucleus;
        orbitSpeed = speed;
        orbitDirection = direction;
    }
}