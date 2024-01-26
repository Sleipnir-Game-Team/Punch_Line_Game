using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Demo.AdditiveScenes;
using FishNet.Managing;

public class checarclique : NetworkBehaviour
{
    [SerializeField] private string nome;
    [SerializeField] GameObject InputManager;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            // GameObject manager = Instantiate(InputManager);
            // NetworkManager networkManager = FindObjectOfType<NetworkManager>();
            // networkManager.ServerManager.Spawn(manager);
        }
        else
        {
            GetComponent<checarclique>().enabled = false;
        }
    }
private void Update()
{
    
    // if (Input.GetKeyDown(KeyCode.Space))
    // {
    //     print("apertou "+nome);
    //     printaServer(gameObject);
    // }
}

[ServerRpc]
public void printaServer(GameObject player)
{
    print("a" + player.GetComponent<checarclique>().GetNome());
    printa(player);
}

[ObserversRpc]
public void printa(GameObject player)
{
    print("b" + player.GetComponent<checarclique>().GetNome());
}

public string GetNome()
{
    return nome;
}

}