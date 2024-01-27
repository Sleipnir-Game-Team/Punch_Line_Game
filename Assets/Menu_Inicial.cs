using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Inicial : MonoBehaviour
{
    [SerializeField] private string NextScene;

    public void PlayButton(){
        Debug.Log("Iniciando jogo");
        PassarCena();
    }

    public void QuitButton(){
        Debug.Log("Drop the mic");
        Application.Quit();
    }

    public void PassarCena(){
        Scene_Manager.GetInstance().LoadScene(NextScene);
    }
}
