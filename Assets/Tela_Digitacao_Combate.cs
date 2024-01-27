using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela_Digitacao_Combate : MonoBehaviour
{
    [SerializeField] private string NextScene;
    [SerializeField] private string LastScene;
    [SerializeField] private GameObject ButtonEndFight;
    
    public void PlayButton(){
        Debug.Log("YOU GOT PUNCH FUCKING LINEDDDDD\nlive with it");
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
