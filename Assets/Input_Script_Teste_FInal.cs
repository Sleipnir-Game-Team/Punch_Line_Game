using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;
using UnityEngine;

public class Input_Script_Teste_Final : MonoBehaviour
{   
    private string word;
    private bool isTyping;

    // Start is called before the first frame update
    void Start()
    {
        isTyping = false;
    }
    
    private void OnEnable(){
        InstanceFinder.ServerManager.RegisterBroadcast<PartialTyping>(OnClientWordBroadcast);
    }

    private void OnDisable()
    {
        InstanceFinder.ServerManager.UnregisterBroadcast<PartialTyping>(OnClientWordBroadcast);
    }

    // Update is called once per frame
    void Update()
    { 
        if(isTyping == false)
        {
            if(Input.GetKeyDown("space"))
            {
                isTyping = true;
            }
        } else {
            TypingListen();
        }
    }
    void TypingListen()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') 
            {
                if (word.Length != 0)
                {
                    word = word.Substring(0, word.Length - 1);
                    print(word);
                }
            }
            else if ((c == '\n') || (c == '\r'))
            {
                int contagem = WordManager.GetInstance().CheckWord(word.ToLower());
                if(contagem > 0){
                    BroadcastWord(word);
                }else{
                    print("Errou patrão");
                }
                word = "";
                isTyping = false;
                return;
            }
            else
            {
                word += c;
                print(word);
            }
        }
    }

    private void BroadcastWord(string word){
        if(InstanceFinder.IsClient){
            InstanceFinder.ClientManager.Broadcast(new PartialTyping(){partialWord = word});
        }
    }

    private void OnClientWordBroadcast(NetworkConnection networkConnection, PartialTyping partialTyping){
        print(networkConnection.ClientId + " disse " + partialTyping.partialWord);
    }

    private struct PartialTyping : IBroadcast{
        public string partialWord;
    }
}

