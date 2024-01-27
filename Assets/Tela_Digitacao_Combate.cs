using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela_Digitacao_Combate : MonoBehaviour
{
    [SerializeField] private string NextScene;
    [SerializeField] private string LastScene;
    [SerializeField] private string MenuScene;
    
    public void PlayButton(){
        Debug.Log("YOU GOT PUNCH FUCKING LINEDDDDD\nlive with it");
        PassarCena();
    }

    public void BackButton(){
        Debug.Log("Vc perdeu O JOGO, volte 1 casa");
        VoltarCena(LastScene);
    }

    public void BackToMenuButton(){
        Debug.Log("Voltando p Menu");
        VoltarCena(MenuScene);
    }

    public void PassarCena(){
        Scene_Manager.GetInstance().LoadScene(NextScene);
    }

    public void VoltarCena(string scene){
        Scene_Manager.GetInstance().LoadScene(scene);
    }
}
