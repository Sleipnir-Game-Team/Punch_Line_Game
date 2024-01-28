using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    private GameObject connectionManager;
    private NetworkConnection connectionData;
    void Start()
    {
        connectionManager = GameObject.Find("ConnectionManager");
        print(connectionManager);
    }
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.M))
        {
            InstanceFinder.ServerManager.RegisterBroadcast<Character_Info>(OnClientWordBroadcast);
            SelectCharacter("Miku");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            InstanceFinder.ServerManager.RegisterBroadcast<Character_Info>(OnClientWordBroadcast);
            SelectCharacter("João");
        }
    }

    void SelectCharacter(string character_name)
    {
        BroadcastChoice(character_name);
    }

    private void BroadcastChoice(string character_name)
    {
        if (InstanceFinder.IsClient)
        {   
            BroadcastWord(character_name);
        } else if (InstanceFinder.IsServer) {
            print(connectionData);
            connectionData = connectionManager.GetComponent<ConnectionManagerReal>().GetConnection(0);
            print("Personagem: "+character_name+", Id: "+connectionData.ClientId);
        }   
    }

    private void BroadcastWord(string character_name){
        if(InstanceFinder.IsClient){
            InstanceFinder.ClientManager.Broadcast(new Character_Info(){character = character_name});
        }
    }

    private void OnClientWordBroadcast(NetworkConnection networkConnection, Character_Info character_info){
        print("Personagem: "+character_info.character+", Id: "+networkConnection.ClientId);
    }

    private struct Character_Info : IBroadcast{
        public string character;

    }
}

