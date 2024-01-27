using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela_Inicial_Combate : MonoBehaviour
{
    [SerializeField] private string NextScene;
    [SerializeField] private string ReturnScene;
    [SerializeField] private GameObject ButtonStartFight;
    
    public void PlayButton(){
        Debug.Log("FAITO");
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
        Scene_Manager.GetInstance().LoadScene(ReturnScene);
    }
}
