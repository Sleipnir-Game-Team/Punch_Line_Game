using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela_Final : MonoBehaviour
{
    [SerializeField] private string NextScene;
    [SerializeField] private string LastScene;
    
    public void PlayButton(){
        Debug.Log("Finalizamo, volta p menu ae, bobão");
        PassarCena();
    }

    public void BackButton(){
        Debug.Log("REEEEEEEEVANCHE NELES SENHORAS E SENHORES");
        VoltarCena(LastScene);
    }

    public void PassarCena(){
        Scene_Manager.GetInstance().LoadScene(NextScene);
    }

    public void VoltarCena(string scene){
        Scene_Manager.GetInstance().LoadScene(scene);
    }
}