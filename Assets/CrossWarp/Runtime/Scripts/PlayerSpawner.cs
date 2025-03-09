using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject ARPlayerPrefab;
    public GameObject DesktopPlayerPrefab;
    public GameObject ImagePrefab;

    public void PlayerJoined(PlayerRef player)
    {
        NetworkObject spawned = null;
        if (player == Runner.LocalPlayer)
        {
            Debug.Log($"PlatformManager.IsDesktop(): {PlatformManager.IsDesktop()}");

            if(PlatformManager.IsDesktop()){
                spawned = Runner.Spawn(DesktopPlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
                Runner.SetPlayerObject(Runner.LocalPlayer, spawned);
                Debug.Log("BCZ disabilito AR controller");
                spawned.gameObject.GetComponent<DesktopPlayerController>().enabled = true;
                return;
            }
            spawned = Runner.Spawn(ARPlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Spawnato : " + spawned.name);
            Runner.SetPlayerObject(Runner.LocalPlayer, spawned);
        }
    }
}
