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
            LosingRight();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WinLeft();
            LoseRight();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WinnerLeft();
            LoserRight();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WinningRight();
            LosingLeft();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            WinRight();
            LoseLeft();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            WinnerRight();
            LoserLeft();
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
        playerDir.GetComponentInChildren<SpriteRenderer>().flipX = true;
    }

    public void WinningLeft(){
        playerEsq.LoadPose("Forte");
    }

    public void WinningRight(){
        playerDir.LoadPose("Forte");
    }

    public void WinLeft(){
        playerEsq.LoadPose("Soco");
    }

    public void WinRight(){
        playerDir.LoadPose("Soco");
    }
    
    public void WinnerLeft(){
        playerEsq.LoadPose("Win");
    }

    public void WinnerRight(){
        playerDir.LoadPose("Win");
    }

    public void LosingLeft(){
        playerEsq.LoadPose("Fraco");
    }

    public void LosingRight(){
        playerDir.LoadPose("Fraco");
    }

    public void LoseLeft(){
        playerEsq.LoadPose("Socado");
    }

    public void LoseRight(){
        playerDir.LoadPose("Socado");
    }
    
    public void LoserLeft(){
        playerEsq.LoadPose("Lose");
    }

    public void LoserRight(){
        playerDir.LoadPose("Lose");
    }
}
