using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public void Init(SphereGenerator generator, Element self);
    public void ManualUpdate(Transform player, float timeStep);
    public void Deinit();
}

public class EnemiesManager : MonoBehaviour
{
    private List<IEnemy> currentEnemies = new();
    private SphereGenerator sphereGenerator;
    private Elements elementsLibrary;

    private Transform playerTransform;
    public void Init(Transform player, SphereGenerator generator, Elements elements)
    {
        sphereGenerator = generator;
        elementsLibrary = elements;

        playerTransform = player;
        
        //StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 500; i++)
        {
            SpawnEnemy(elementsLibrary.GetRandomElement());
            yield return new WaitForEndOfFrame();
        }
    }

    public void SpawnEnemy(Element source)
    {
        //TODO: replace with prefab
        GameObject enemy = new GameObject(source.elementName + " enemy");
        var controller = enemy.AddComponent<BasicEnemy>();
        controller.Init(sphereGenerator, source);
        currentEnemies.Add(controller);
        
        enemy.transform.position = new Vector3(Random.Range(-40, 40), enemy.transform.position.y, Random.Range(-40, 40));
    }

    public void ManualUpdate(float timeStep)
    {
        foreach (var enemy in currentEnemies)
        {
            enemy.ManualUpdate(playerTransform, timeStep);
        }
    }
}