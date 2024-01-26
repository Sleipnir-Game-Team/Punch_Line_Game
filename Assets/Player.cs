using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string pose;
    [SerializeField] private string character;

    public string GetPose(){
        return pose;
    }

    public string GetCharacter(){
        return character;
    }

    public void SetPose(string pose){
        this.pose = pose;
    }

    public void SetCharacter(string character){
        this.character = character;
    }

    public void LoadPose(string pose){
        this.pose = pose;
        Sprite novaPose  = Resources.Load<Sprite>("SpriteTeste/"+pose+"-"+character);
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = novaPose;
    }

}
