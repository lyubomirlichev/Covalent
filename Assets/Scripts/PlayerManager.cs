using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float electronSpeedFactor = 150;
    
    private PlayerMovement movementControl;
    private List<GameObject> electronGroups = new();

    public void Init(SphereGenerator generator, Element startingElement)
    {
        movementControl = gameObject.AddComponent<PlayerMovement>();
        movementControl.Init();

        //TODO: make them spaced out a bit
        for (int i = 0; i < startingElement.numProtons; i++)
        {
            var protonSphere = generator.CreateProton(0.1f);
            protonSphere.name = "Proton";
            protonSphere.transform.SetParent(transform, false);
        }

        for (int i = 0; i < startingElement.numNeutrons; i++)
        {
            var neutronSphere = generator.CreateNeutron(0.1f);
            neutronSphere.name = "Neutron";
            neutronSphere.transform.SetParent(transform, false);
        }

        for (int i = 0; i < startingElement.electrons.Length; i++)
        {
            GameObject electronGroup = new GameObject("electron group" + i);
            electronGroup.transform.SetParent(transform, false);

            for (int j = 0; j < startingElement.electrons[i]; j++)
            {
                var electronSphere = generator.CreateElectron(0.05f);
                electronSphere.name = "Electron";
                electronSphere.transform.SetParent(electronGroup.transform, false);
                float radius = (i + 1) * 0.2f;

                float angle = (j + 1) * 2 * Mathf.PI / startingElement.electrons[i];
                angle += (180f * i); // offset
                float x = Mathf.Sin(angle) * radius;
                float z = Mathf.Cos(angle) * radius;
                electronSphere.transform.Translate(new Vector3(x, 0, z));
            }

            electronGroups.Add(electronGroup);
        }
    }

    public void ManualUpdate(float timeStep)
    {
        movementControl.ManualUpdate(timeStep);

        for (int i = 0; i < electronGroups.Count; i++)
        {
            electronGroups[i].transform.Rotate(Vector3.up, (i % 2 == 0 ? 1 : -1) * (electronSpeedFactor / (i + 1)) * timeStep);
        }
    }
}