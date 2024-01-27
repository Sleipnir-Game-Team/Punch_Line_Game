using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    private static WordManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    private Dictionary<string, int> words;
    private List<string> palavrasUsadas;

    // Start is called before the first frame update
    void Start()
    {
        words = new Dictionary<string, int>();
        palavrasUsadas = new List<string>();
        PopulateWordDict();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateWordDict(){
        string[] lines = File.ReadAllLines("Assets\\palavras");

        foreach (string line in lines)
            words.Add(line, line.Length);
    }

    public int CheckWord(string word){
        bool existe = words.TryGetValue(word, out int resposta);
        if(palavrasUsadas.Contains(word)){
                print("Ja foi parça");
                return -1;
        }else{
            palavrasUsadas.Add(word);
            if(existe){
                return resposta;
            }else{
                return -1;
            }
        }
        
    }

    public static WordManager GetInstance(){
        return instance;
    }
}
