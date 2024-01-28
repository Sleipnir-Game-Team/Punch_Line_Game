using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;

public class Read_Speaker : MonoBehaviour
{
    private TTSSpeaker speaker;
    // Start is called before the first frame update
    void Start()
    {
        SpVoice voice = new SpVoice();
        ReadWord("Pica");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TSS.InterruptAll();
        }
    }

    void ReadWord(string word)
    {
        TTS.Say(word, speaker);
    }
}
