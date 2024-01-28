using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Script_Teste2 : MonoBehaviour
{   
    private string word;
    private bool isTyping;

    // Start is called before the first frame update
    void Start()
    {
        isTyping = false;
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
                }
            }
            else if ((c == '\n') || (c == '\r'))
            {
                int contagem = WordManager.GetInstance().CheckWord(word.ToLower());
                if(contagem > 0){
                    print(contagem);
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
}

