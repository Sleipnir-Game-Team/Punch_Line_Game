using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager instance;

    [SerializeField] private GameObject persEsquerdaPrefab;
    private GameObject persEsquerda;
    [SerializeField] private Vector3 spawnEsquerda;
    private Player playerEsq;

    [SerializeField] private GameObject persDireitaPrefab;
    private GameObject persDireita;
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
            WinningLeft();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WinLeft();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WinnerLeft();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WinningRight();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            WinRight();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            WinnerRight();
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
    }

    public void SpawnCharacters(){
        Destroy(persEsquerda);
        persEsquerda = Instantiate(persEsquerdaPrefab, spawnEsquerda, Quaternion.identity);
        playerEsq = persEsquerda.GetComponent<Player>();
        playerEsq.LoadPose("Carregando");

        Destroy(persDireita);
        persDireita = Instantiate(persDireitaPrefab, spawnDireita, Quaternion.identity);
        playerDir = persDireita.GetComponent<Player>();
        playerDir.LoadPose("Carregando");
    }

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

    public static CharacterManager GetInstance(){
        return instance;
    }
}
