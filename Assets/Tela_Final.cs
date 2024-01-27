using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela_Final : MonoBehaviour
{
    [SerializeField] private string NextScene;
    [SerializeField] private string LastScene;
    [SerializeField] private GameObject ButtonBackToMenu;
    
    public void PlayButton(){
        Debug.Log("Finalizamo, volta p menu ae, bobão");
        PassarCena();
    }

    public void BackButton(){
        Debug.Log("Voltando p Menu");
        VoltarCena();
    }

    public void PassarCena(){
        Scene_Manager.GetInstance().LoadScene(NextScene);
    }

    public void VoltarCena(){
        Scene_Manager.GetInstance().LoadScene(LastScene);
    }
}