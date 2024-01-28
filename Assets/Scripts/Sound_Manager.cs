using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadSpeaker;

public class Sound_Manager : MonoBehaviour
{
    private static Sound_Manager instance;
    private List<AudioSource> Audios;
    private Queue<List<(AudioClip,bool)>> sounds;
    private List<(AudioClip,bool)> musics;
    private AudioSource music_source;
    private List<AudioSource> removed;
    private TTSSpeaker speaker;
    private Queue<string> words;
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        TTS.Init();
        Audios = new List<AudioSource>();
        sounds = new Queue<List<(AudioClip,bool)>>();
        music_source = gameObject.GetComponent<AudioSource>();
        removed = new List<AudioSource>();
        speaker = gameObject.GetComponent<TTSSpeaker>();
        words = new Queue<string>();

        WordQueue("Soco");
        WordQueue("Grande");
        WordQueue("Rápido");
        WordQueue("Gigante");
    }

    void Update()
    {
        VerifieAudio();
        VerifieQueue();
        VerifieWords();
    }

    public void WordQueue(string word)
    {
        words.Enqueue(word);
    } 

    public void WordsQueueClean()
    {
        words.Clear();
    }

    void VerifieWords()
    {
        if (speaker.audioSource.isPlaying == false)
        {   
            if (words.Count > 0)
            {
                var wordDequeue = words.Dequeue();
                TTS.Say(wordDequeue, speaker);
            }
        }
    }

    public void LoadMusic(string type, string name, bool loop)
    {    
        musics = new List<(AudioClip,bool)>();
        AudioClip music = Resources.Load<AudioClip>("Música-Sons/" + type + "/" + name);
        musics.Add((music, loop));
        sounds.Enqueue(musics);
    }

    public void LoadSound(string type, string name)
    {   
        AudioSource Audio = gameObject.AddComponent<AudioSource>();
        Audios.Add(Audio);
        AudioClip sound = Resources.Load<AudioClip>("Música-Sons/" + type + "/" + name);
        print(sound);
        Audio.clip = sound;
        Audio.Play();
    }

    void VerifieAudio()
    {
        if (Audios.Count > 0)
        {
            foreach (AudioSource audio in Audios)
            {
                print(audio);
                if (audio.isPlaying == false)
                {   
                    removed.Add(audio);                    
                }
            }

            foreach(AudioSource removed_audio in removed)
            {
                Audios.Remove(removed_audio);
                Destroy(removed_audio);
            }
            
            removed.Clear();

        }
    }

    void VerifieQueue()
    {
        if (music_source.isPlaying == false)
        {   
            if (sounds.Count > 0)
            {
                var musicList = sounds.Dequeue();
                print(musicList[0].Item1);
                print(musicList[0].Item2);
                music_source.clip = musicList[0].Item1;
                music_source.loop = musicList[0].Item2;
                music_source.Play();
            }
        }
    }

    public void CleanQueue()
    {
        sounds.Clear();
    }

    public static Sound_Manager GetInstance(){
        return instance;
    }
}
