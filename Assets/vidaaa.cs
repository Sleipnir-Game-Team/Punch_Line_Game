using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;
using Unity.VisualScripting;
using UnityEngine;

public class vidaaa : MonoBehaviour
{
    [SerializeField] private int maxlife;
    private int life;
    [SerializeField] private int damage;
    private void OnEnable()
    {
        InstanceFinder.ServerManager.RegisterBroadcast<Lifeactual>(OnClientLifeBroadcast);
    }

    private void OnDisable()
    {
        InstanceFinder.ServerManager.UnregisterBroadcast<Lifeactual>(OnClientLifeBroadcast);
    }


        public void Start()
        {
            life = maxlife;
            string lifeText = life.ToString();
            print("Vida " + lifeText);
        }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            
            damagecalculation();
            print(life);
        }
    }

        public void damagecalculation()
        {
            life = life - damage;
            BroadcastLife(life);
        }
      //  public int Getlife()
      //   {
      //      return life;
      //   }
    private struct Lifeactual : IBroadcast
    {
        public int Lifeatt;
    }
    private void BroadcastLife(int life)
    {
        if (InstanceFinder.IsClient)
        {
            InstanceFinder.ClientManager.Broadcast(new Lifeactual() { Lifeatt = life });
        }
    }

    private void OnClientLifeBroadcast(NetworkConnection networkConnection, Lifeactual lifeactual)
    {
        print(networkConnection.ClientId + " sua vida e " + lifeactual.Lifeatt);
    }
}