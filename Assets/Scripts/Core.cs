using System.Collections.Generic;
using Cinemachine;
using UnityEngine;



public class Core : MonoBehaviour
{
    private PlayerManager player;
    private Elements elementsLibrary;
    
    private void Start()
    {
        elementsLibrary = gameObject.AddComponent<Elements>();
        elementsLibrary.Init();
        
        var playerPrefab = Instantiate(Resources.Load("Prefabs/Player") as GameObject);
        var cameraPrefab = Instantiate(Resources.Load("Prefabs/Main Camera") as GameObject);
        if (cameraPrefab == null || playerPrefab == null) return;
        
        player = playerPrefab.GetComponent<PlayerManager>();
        var cam = cameraPrefab.GetComponent<CinemachineVirtualCamera>();
        
        cam.Follow = player.transform;
        cam.LookAt = player.transform;

        var playerElement = elementsLibrary.GetElementByName("Hydrogen");
        player.Init(playerElement);
        
    }

    private void Update()
    {
        player.ManualUpdate();
    }
}
