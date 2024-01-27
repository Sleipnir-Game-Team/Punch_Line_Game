using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Inicial : MonoBehaviour
{
    [SerializeField] private string NextScene;
    [SerializeField] private GameObject ButtonPlay;

    public void PlayButton(){
        Debug.Log("Iniciando jogo");
        PassarCena();
    }

    public void QuitButton(){
        Application.Quit();
        Debug.Log("Drop the mic");
    }

    public void PassarCena(){
        Scene_Manager.GetInstance().LoadScene(NextScene);
    }
}
