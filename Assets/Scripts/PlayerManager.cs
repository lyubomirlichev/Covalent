using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public void Init()
    {
        var movementControl = GetComponent<PlayerMovement>();
        movementControl.Init();
        
        var generator = GetComponent<SphereGenerator>();
        var proton = generator.CreateSphereGameObject();
        proton.transform.SetParent(transform);
        proton.name = "proton";
        proton.transform.localPosition = Vector3.zero;
    }
}
