using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Transporting;
using UnityEngine;

public class ConnectionManagerReal : MonoBehaviour
{
    private static ConnectionManagerReal instance;
    private NetworkManager networkManager;

    [SerializeField] private string ip;
    [SerializeField] private ushort port;
    private NetworkConnection networkConnectionEsq;
    private NetworkConnection networkConnectionDir;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null){
            instance = this;
            networkManager = FindObjectOfType<NetworkManager>();
            networkManager.ServerManager.OnRemoteConnectionState += OnConnectedClient;
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

    public void OnConnectedClient(NetworkConnection networkConnection, RemoteConnectionStateArgs args){
        if(networkConnection.ClientId.Equals(0)){
            networkConnectionEsq = networkConnection;
            print(networkConnectionEsq);
        }else if(networkConnection.ClientId.Equals(1)){
            networkConnectionDir = networkConnection;
            print(networkConnectionDir);
        }
    }

    public NetworkConnection GetConnection(int id){
        if(id == 0){
            return networkConnectionEsq;
        }else if(id == 1){
            return networkConnectionDir;
        }else{
            return null;
        }
    }

    public static ConnectionManagerReal GetInstance(){
        return instance;
    }
}
