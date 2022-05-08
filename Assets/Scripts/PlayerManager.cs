using System.Collections.Generic;
using System.ServiceModel.Syndication;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private List<Electron> electrons = new();

    public void Init(Element startingElement)
    {
        var movementControl = GetComponent<PlayerMovement>();
        movementControl.Init();

        var generator = GetComponent<SphereGenerator>();

        //TODO: make them spaced out a bit
        for (int i = 0; i < startingElement.numProtons; i++)
        {
            var protonSphere = generator.CreateProton(0.1f);
            protonSphere.name = "Proton";
            protonSphere.transform.SetParent(transform);
        }

        for (int i = 0; i < startingElement.numNeutrons; i++)
        {
            var neutronSphere = generator.CreateNeutron(0.1f);
            neutronSphere.name = "Neutron";
            neutronSphere.transform.SetParent(transform);
        }

        for (int i = 0; i < startingElement.electrons.Length; i++)
        {
            for (int j = 0; j < startingElement.electrons[i]; j++)
            {
                var electronSphere = generator.CreateElectron(0.05f);
                electronSphere.name = "Electron";
                electronSphere.transform.SetParent(transform);
                electronSphere.transform.Translate(new Vector3((j+1)*0.3f,0,0));
                
                var electron = electronSphere.AddComponent<Electron>();
                electron.Init(transform, 100f, 1f); // TODO: replace transform with an empty anchor
                electrons.Add(electron);
            }
        }
    }

    public void ManualUpdate()
    {
        foreach (var electron in electrons)
        {
            electron.ManualUpdate();
        }
    }
}