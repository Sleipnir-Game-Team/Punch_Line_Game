using System.Collections;
using System.Collections.Generic;
using FishNet.Managing;
using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    private static ConnectionManager instance;
    private NetworkManager networkManager;

    [SerializeField] private string ip;
    [SerializeField] private ushort port;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    public void Update(){
        if (Input.GetKeyDown(KeyCode.S))
        {
            ConnectServer(port);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ConnectClient(ip,port);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Desconnect();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            DesconnectServer();
        }
    }

    public void ConnectClient(string address, ushort port){
        networkManager = FindObjectOfType<NetworkManager>();
        networkManager.ClientManager.StartConnection(address,port);
    }

    public void ConnectServer(ushort port){
        networkManager = FindObjectOfType<NetworkManager>();
        networkManager.ServerManager.StartConnection(port);
    }

    public void DesconnectServer(){
        networkManager.ServerManager.StopConnection(false);
    }

    public void Desconnect(){
        networkManager.ClientManager.StopConnection();
    }
}
