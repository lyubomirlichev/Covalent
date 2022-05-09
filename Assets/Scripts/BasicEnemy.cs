using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, IEnemy
{
    private List<Electron> electrons = new();

    public void Init(SphereGenerator sphereGenerator, Element source)
    {
        gameObject.AddComponent<SphereCollider>();

        //TODO: reuse for player and enemy
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
            for (int j = 0; j < source.electrons[i]; j++)
            {
                var electronSphere = sphereGenerator.CreateElectron(0.05f);
                electronSphere.name = "Electron";
                electronSphere.transform.SetParent(transform);
                float radius = (i + 1) * 0.2f;

                float angle = (j + 1) * 2 * Mathf.PI / source.electrons[i];
                angle += (180f * i); // offset
                float x = Mathf.Sin(angle) * radius;
                float z = Mathf.Cos(angle) * radius;
                electronSphere.transform.Translate(new Vector3(x, 0, z));

                float direction = i % 2 == 0 ? 1 : -1;

                var electron = electronSphere.AddComponent<Electron>();
                electron.Init(transform, 200f / (i + 1), direction); // TODO: replace transform with an empty anchor
                electrons.Add(electron);
            }
        }

        transform.position = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
    }

    public void ManualUpdate(float timeStep)
    {
        foreach (var electron in electrons)
        {
            electron.ManualUpdate(timeStep);
        }
    }

    public void Deinit()
    {
    }
}