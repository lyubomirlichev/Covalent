using Cinemachine;
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
        if (playerPrefab == null) return;
        
        player = playerPrefab.GetComponent<PlayerManager>();
        enemiesManager = GetComponent<EnemiesManager>();
        var generator = GetComponent<SphereGenerator>();
        generator.Init();
        
        var cam = Camera.main?.transform.GetComponent<CinemachineVirtualCamera>();
        cam.Follow = player.transform;
        cam.LookAt = player.transform;

        var playerElement = elementsLibrary.GetElementByName("Helium");
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
