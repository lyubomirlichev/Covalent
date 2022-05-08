
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Core : MonoBehaviour
{
    private PlayerManager player;
    private void Start()
    {
        var playerPrefab = Instantiate(Resources.Load("Prefabs/Player") as GameObject);
        var cameraPrefab = Instantiate(Resources.Load("Prefabs/Main Camera") as GameObject);
        if (cameraPrefab == null || playerPrefab == null) return;
        
        player = playerPrefab?.GetComponent<PlayerManager>();
        var cam = cameraPrefab?.GetComponent<CinemachineVirtualCamera>();
        
        cam.Follow = player.transform;
        cam.LookAt = player.transform;

        player.Init();
    }
}
