using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.M))
        {
            BroadcastCall();
            SelectCharacter("Miku");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            BroadcastCall();
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
            InstanceFinder.ClientManager.Broadcast(new Charecter_Info(){Character = character_name, playerType = "Client"});
        } else if (InstanceFinder.IsServer) {
            InstanceFinder.ClientManager.Broadcast(new Charecter_Info(){Character = character_name, playerType = "Server"});
        }
    }
    private void BroadcastCall()
    {
        InstanceFinder.ServerManager.RegisterBroadcast<Charecter_Info>(BroadcastResult);
    }
    private void BroadcastResult(NetworkConnection networkConnection, Charecter_Info charecter_info){
        print("Character: "+charecter_info.Character+", Type: "+charecter_info.playerType);
    }

    private struct Charecter_Info : IBroadcast
    {
        public string Character;
        public string playerType;
    }
}
