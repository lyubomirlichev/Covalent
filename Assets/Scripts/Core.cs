using Cinemachine;
using EasyButtons;
using UnityEngine;

public class Core : MonoBehaviour
{
    private PlayerManager player;
    private Elements elementsLibrary;
    private EnemiesManager enemiesManager;
    
    private void Start()
    {
        elementsLibrary = gameObject.AddComponent<Elements>();
        elementsLibrary.Init();
        
        var playerPrefab = Instantiate(Resources.Load("Prefabs/Player") as GameObject);
        var cameraPrefab = Instantiate(Resources.Load("Prefabs/Main Camera") as GameObject);
        if (cameraPrefab == null || playerPrefab == null) return;
        
        player = playerPrefab.GetComponent<PlayerManager>();
        enemiesManager = GetComponent<EnemiesManager>();
        var cam = cameraPrefab.GetComponent<CinemachineVirtualCamera>();
        var generator = GetComponent<SphereGenerator>();
        generator.Init();
        
        cam.Follow = player.transform;
        cam.LookAt = player.transform;

        var playerElement = elementsLibrary.GetElementByName("Test");
        player.Init(generator, playerElement);
        
        enemiesManager.Init(player.transform,generator,elementsLibrary);
    }
    
    private void Update()
    {
        var timeStep = Time.deltaTime;
        player.ManualUpdate(timeStep);
        enemiesManager.ManualUpdate(timeStep);
    }
}
