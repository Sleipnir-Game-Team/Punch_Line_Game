using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SyncVar] [SerializeField] private string pose;
    [SyncVar] [SerializeField] private string character;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if(!base.IsOwner){
            GetComponent<Player>().enabled = false;
        }
    }

    private void Update()
    {
    }
    public string GetPose(){
        return pose;
    }

    public string GetCharacter(){
        return character;
    }

    public void SetPose(string pose){
        this.pose = pose;
    }

    public void SetCharacter(string character){
        this.character = character;
    }

    [ObserversRpc]
    public void LoadPose(string pose){
        this.pose = pose;
        Sprite novaPose  = Resources.Load<Sprite>("SpriteTeste/"+pose+"-"+character);
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = novaPose;
    }

    public void LEFT_PUNCH(){
        CharacterManager.GetInstance().WinLeft();
    }

    public void RIGHT_PUNCH(){
        CharacterManager.GetInstance().WinRight();
    }

    public void STAND_UP(){
        CharacterManager.GetInstance().Recover();
    }

    [ObserversRpc]
    public void Winning(){
        LoadPose("Forte");
        GetComponent<Animator>().SetInteger("Status", 1);
        GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);
    }

    [ObserversRpc]
    public void Losing(){
        LoadPose("Fraco");
        GetComponent<Animator>().SetInteger("Status", 3);
        GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);
    }


    [ObserversRpc]
    public void Win(){
        LoadPose("Soco");
        GetComponent<Animator>().SetInteger("Status", 2);
        GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);
    }

    [ObserversRpc]
    public void Lose(){
        LoadPose("Socado");
        GetComponent<Animator>().SetInteger("Status", 4);
    }
    
    [ObserversRpc]
    public void Winner(){
        LoadPose("Win");
        GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);
        GetComponentsInChildren<Animator>()[1].SetFloat("speedMt", 10);
    }

    [ObserversRpc]
    public void Loser(){
        LoadPose("Lose");
        GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);
        GetComponent<Animator>().SetInteger("Status", 5);
    }

    public void Recover(NetworkObject pers, Vector3 spawn){
        RecoverServer(pers, spawn);
    }

    //[ObserversRpc]
    public void RecoverServer(NetworkObject pers, Vector3 spawn){
        print("a "+spawn);
        print(pers.OwnerId);
        RecoverClient(pers, spawn);
    }

    //[ServerRpc]
    public void RecoverClient(NetworkObject pers, Vector3 spawn){
        print("b "+spawn);
        pers.transform.position = spawn;
        print("c "+pers.transform.position);
        pers.GetComponent<Player>().LoadPose("Carregando");

        pers.GetComponent<Animator>().SetInteger("Status", 0);
        pers.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);
    }



}
