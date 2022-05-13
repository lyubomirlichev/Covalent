using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, IEnemy
{
    private float electronSpeedFactor = 150;
    private float moveSpeed = 5;
    
    private List<GameObject> electronGroups = new();

    public void Init(SphereGenerator sphereGenerator, Element source)
    {
        transform.localPosition = new Vector3(0, 0.5f, 0);
        gameObject.AddComponent<SphereCollider>();

        //TODO: reuse some for player and enemy
        for (int i = 0; i < source.numProtons; i++)
        {
            var protonSphere = sphereGenerator.CreateProton(0.1f);
            protonSphere.name = "Proton";
            protonSphere.transform.SetParent(transform, false);
        }

        for (int i = 0; i < source.numNeutrons; i++)
        {
            var neutronSphere = sphereGenerator.CreateNeutron(0.15f);
            neutronSphere.name = "Neutron";
            neutronSphere.transform.SetParent(transform, false);
        }

        for (int i = 0; i < source.electrons.Length; i++)
        {
            GameObject electronGroup = new GameObject("electron group" + i);
            electronGroup.transform.SetParent(transform, false);

            for (int j = 0; j < source.electrons[i]; j++)
            {
                var electronSphere = sphereGenerator.CreateElectron(0.05f);
                electronSphere.name = "Electron";
                electronSphere.transform.SetParent(electronGroup.transform, false);
                float radius = (i + 1) * 0.2f;

                float angle = (j + 1) * 2 * Mathf.PI / source.electrons[i];
                angle += (180f * i); // offset
                float x = Mathf.Sin(angle) * radius;
                float z = Mathf.Cos(angle) * radius;
                electronSphere.transform.Translate(new Vector3(x, 0, z));
            }

            electronGroups.Add(electronGroup);
        }
    }

    public void ManualUpdate(Transform player, float timeStep)
    {
        for (int i = 0; i < electronGroups.Count; i++)
        {
            electronGroups[i].transform.Rotate(Vector3.up, (i % 2 == 0 ? 1 : -1) * (electronSpeedFactor / (i + 1)) * timeStep);
        }

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        direction.y = 0;
        transform.Translate(direction * (moveSpeed * timeStep));
    }

    public void Deinit()
    {
    }
}