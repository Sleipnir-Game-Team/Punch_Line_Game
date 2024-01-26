using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Script : MonoBehaviour
{   
    private string word;
    private char character;

    // Start is called before the first frame update
    void Start()
    {
        word = null;
    }

    // Update is called once per frame
    void Update()
    {   
        foreach (char c in Input.inputString)
        {
            if (c == '\b') 
            {
                return;
            }
            else if ((c == '\n') || (c == '\r'))
            {
                return;
            }
            else if (char.IsLetter(c))
            {
                character = c;
                print(character);
            }
        }
    }
    void GetCharacter()
    {
        return;
    }
}
