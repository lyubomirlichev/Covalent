using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class PlayerManager : MonoBehaviour
{
    private float electronSpeedFactor = 150;

    private PlayerMovement movementControl;
    private PlayerAttacks playerAttacks;
    private List<GameObject> electronGroups = new();
    private List<Electron> electrons = new();
    
    public void Init(SphereGenerator generator, Element startingElement)
    {
        movementControl = gameObject.AddComponent<PlayerMovement>();
        playerAttacks = gameObject.AddComponent<PlayerAttacks>();
        
        movementControl.Init();
        playerAttacks.Init(OnFire);
        
        for (int i = 0; i < startingElement.numProtons; i++)
        {
            var protonSphere = generator.CreateProton(0.08f);
            Vector3 dir = Random.insideUnitSphere.normalized;
            protonSphere.transform.position = (dir / 15f) * (i * 0.15f);
            protonSphere.name = "Proton";
            protonSphere.transform.SetParent(transform, false);
        }

        for (int i = 0; i < startingElement.numNeutrons; i++)
        {
            var neutronSphere = generator.CreateNeutron(0.08f);
            Vector3 dir = Random.insideUnitSphere.normalized;
            neutronSphere.transform.position = (dir / 15f) * (i * 0.15f);
            neutronSphere.name = "Neutron";
            neutronSphere.transform.SetParent(transform, false);
        }

        float innerOrbitOffset = (startingElement.numNeutrons + startingElement.numProtons) / 2f * 0.005f;

        for (int i = 0; i < startingElement.electrons.Length; i++)
        {
            GameObject electronGroup = new GameObject("electron group" + i);
            electronGroup.transform.SetParent(transform, false);

            for (int j = 0; j < startingElement.electrons[i]; j++)
            {
                var electronSphere = generator.CreateElectron(0.05f);
                electronSphere.name = "Electron";
                electronSphere.transform.SetParent(electronGroup.transform, false);
                float radius = innerOrbitOffset + (i + 1) * 0.2f; //0.2f is hard offset

                float angle = (j + 1) * 2 * Mathf.PI / startingElement.electrons[i];
                angle += (180f * i); // offset
                float x = Mathf.Sin(angle) * radius;
                float z = Mathf.Cos(angle) * radius;
                electronSphere.transform.Translate(new Vector3(x, 0, z));
                
                var item = electronSphere.AddComponent<Electron>();
                item.Init();
                electrons.Add(item);
            }
            
            electronGroups.Add(electronGroup);
        }
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        //Firing is WIP, need to decide on the mechanics
        var ele = electrons[^1];
        ele.OnFired?.Invoke();
        electrons.RemoveAt(electrons.IndexOf(ele));
    }
    
    public void ManualUpdate(float timeStep)
    {
        movementControl.ManualUpdate(timeStep);

        for (int i = 0; i < electronGroups.Count; i++)
        {
            electronGroups[i].transform.Rotate(Vector3.up, (i % 2 == 0 ? 1 : -1) * (electronSpeedFactor / (i + 1)) * timeStep);
        }
    }

    private void Highlight(Electron target)
    {
        
    }
}