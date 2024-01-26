using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Demo.AdditiveScenes;

public class checarclique : NetworkBehaviour
{
    [SerializeField] private string nome;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {

        }
        else
        {
            GetComponent<checarclique>().enabled = false;
        }
    }
private void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
       printaServer(gameObject);
    }
}

[ServerRpc]
public void printaServer(GameObject player)
{
    printa(player);
}

[ObserversRpc]
public void printa(GameObject player)
{
    print(player.GetComponent<checarclique>().GetNome());
}

public string GetNome()
{
    return nome;
}

}