using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveTest : MonoBehaviour
{
    public class Player
    {
        public bool[] flag = new bool[10];
    }

    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();
        player.flag[1] = true;
        string jsonstr = JsonUtility.ToJson(player);
        Debug.Log(jsonstr);
        File.WriteAllText("Assets\\Test.json", jsonstr);

        string json = File.ReadAllText("Assets\\test.json");
        Player player2 = JsonUtility.FromJson<Player>(json);
        for(int i = 0; i < player2.flag.Length;i++)Debug.Log(player2.flag[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
