using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Object;
using UnityEngine;

public class CharacterManagerReal : MonoBehaviour
{
    private static CharacterManagerReal instance;

    [SerializeField] private NetworkObject persEsquerdaPrefab;
    private NetworkObject persEsquerda;
    [SerializeField] private Vector3 spawnEsquerda;
    private Player playerEsq;

    [SerializeField] private NetworkObject persDireitaPrefab;
    private NetworkObject persDireita;
    [SerializeField] private Vector3 spawnDireita;
    private Player playerDir;

    // 1 digitando capsula
    // 2 vai bater quadrado
    // 3 vai tomar circulo
    // 4 batendo   diamante
    // 5 tomando   triangulo
    // 6 vitoria   hexagono
    // 7 derrota   erro
    [SerializeField] private List<Sprite> sprites;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SpawnCharacters();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //WinningLeft();
            playerEsq.Winning();
            playerDir.Losing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //WinLeft();
            playerEsq.Win();
            playerDir.Lose();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //WinnerLeft();
            playerEsq.Winner();
            playerDir.Loser();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // WinningRight();
            playerDir.Winning();
            playerEsq.Losing();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // WinRight();
            playerDir.Win();
            playerEsq.Lose();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // WinnerRight();
            playerDir.Winner();
            playerEsq.Loser();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            float spmte = playerEsq.GetComponentsInChildren<Animator>()[1].GetFloat("speedMt");
            float spmtd = playerDir.GetComponentsInChildren<Animator>()[1].GetFloat("speedMt");
            playerEsq.GetComponentsInChildren<Animator>()[1].SetFloat("speedMt", spmte*2f);
            playerDir.GetComponentsInChildren<Animator>()[1].SetFloat("speedMt", spmtd*0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            float spmte = playerEsq.GetComponentsInChildren<Animator>()[1].GetFloat("speedMt");
            float spmtd = playerDir.GetComponentsInChildren<Animator>()[1].GetFloat("speedMt");
            playerEsq.GetComponentsInChildren<Animator>()[1].SetFloat("speedMt", spmte*0.5f);
            playerDir.GetComponentsInChildren<Animator>()[1].SetFloat("speedMt", spmtd*2f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            playerEsq.Recover(persEsquerda, spawnEsquerda);
            playerDir.Recover(persDireita, spawnDireita);
        }
    }

    public void SpawnCharacters(){
        
        if(InstanceFinder.ServerManager.Clients.Keys.Count == 2){
            persEsquerda = Instantiate(persEsquerdaPrefab);
            InstanceFinder.ServerManager.Spawn(persEsquerda,ConnectionManagerReal.GetInstance().GetConnection(0));
            playerEsq = persEsquerda.GetComponent<Player>();
            persEsquerda.GetComponent<Input_Script_Teste2>().SpawnBox();
            //persEsquerda.transform.position = spawnEsquerda;

            persDireita = Instantiate(persDireitaPrefab);
            InstanceFinder.ServerManager.Spawn(persDireita,ConnectionManagerReal.GetInstance().GetConnection(1));
            playerDir = persDireita.GetComponent<Player>();
            //persDireita.transform.position = spawnDireita;
            
            playerEsq.Recover(persEsquerda, spawnEsquerda);
            playerDir.Recover(persDireita, spawnDireita);
        } else if(InstanceFinder.ServerManager.Clients.Keys.Count < 2){
            print("Algum cliente não está conectado");
        } else {
            print("?????????????????????????????????????????????");
        }

    }

    /*
    public void WinningLeft(){
        playerEsq.LoadPose("Forte");
        playerEsq.GetComponent<Animator>().SetInteger("Status", 1);
        playerEsq.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);


        playerDir.LoadPose("Fraco");
        playerDir.GetComponent<Animator>().SetInteger("Status", 3);
        playerDir.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);
    }

    public void WinningRight(){
        playerDir.LoadPose("Forte");
        playerDir.GetComponent<Animator>().SetInteger("Status", 1);
        playerDir.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);

        
        playerEsq.LoadPose("Fraco");
        playerEsq.GetComponent<Animator>().SetInteger("Status", 3);
        playerEsq.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);
    }

    public void WinLeft(){
        playerEsq.LoadPose("Soco");
        playerEsq.GetComponent<Animator>().SetInteger("Status", 2);
        playerEsq.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);

        
        playerDir.LoadPose("Socado");
        playerDir.GetComponent<Animator>().SetInteger("Status", 4);
    }

    public void WinRight(){
        playerDir.LoadPose("Soco");
        playerDir.GetComponent<Animator>().SetInteger("Status", 2);
        playerDir.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);

        
        playerEsq.LoadPose("Socado");
        playerEsq.GetComponent<Animator>().SetInteger("Status", 4);
        
    }
    
    public void WinnerLeft(){
        playerEsq.LoadPose("Win");
        playerEsq.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);
        playerEsq.GetComponentsInChildren<Animator>()[1].SetFloat("speedMt", 10);

        playerDir.LoadPose("Lose");
        playerDir.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);
        playerDir.GetComponent<Animator>().SetInteger("Status", 5);
    }

    public void WinnerRight(){
        playerDir.LoadPose("Win");
        playerDir.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);
        playerDir.GetComponentsInChildren<Animator>()[1].SetFloat("speedMt", 10);

        playerEsq.LoadPose("Lose");
        playerEsq.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 1);
        playerEsq.GetComponent<Animator>().SetInteger("Status", 5);
    }

    public void Recover(){
        playerEsq.LoadPose("Carregando");
        playerDir.LoadPose("Carregando");

        playerEsq.GetComponent<Animator>().SetInteger("Status", 0);
        playerEsq.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);

        playerDir.GetComponent<Animator>().SetInteger("Status", 0);
        playerDir.GetComponentsInChildren<Animator>()[1].SetInteger("Status", 0);
    }
    */
    public static CharacterManagerReal GetInstance(){
        return instance;
    }
}
