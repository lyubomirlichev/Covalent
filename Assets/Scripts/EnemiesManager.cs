using System.Collections.Generic;
using System.ServiceModel.Syndication;
using UnityEngine;

public interface IEnemy
{
    public void Init(SphereGenerator generator, Element self);
    public void ManualUpdate(float timeStep);
    public void Deinit();
}

public class EnemiesManager : MonoBehaviour
{
    private List<IEnemy> currentEnemies = new();
    private SphereGenerator sphereGenerator;

    public void Init(SphereGenerator generator)
    {
        sphereGenerator = generator;
    }

    public void SpawnEnemy(Element source)
    {
        //TODO: replace with prefab
        GameObject enemy = new GameObject(source.elementName + " enemy");
        var controller = enemy.AddComponent<BasicEnemy>();
        controller.Init(sphereGenerator, source);
        currentEnemies.Add(controller);
    }

    public void ManualUpdate(float timeStep)
    {
        foreach (var enemy in currentEnemies)
        {
            enemy.ManualUpdate(timeStep);
        }
    }
}