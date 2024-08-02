using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainGameManager : MonoBehaviour {
    public static MainGameManager Instance;
    public string playerName;
    public int maxScore;

    [System.Serializable]
    public class SaveData {
        public string playerName;
        public int maxScore;
    }

    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameAndScore();
    }

    public void SaveNameAndScore() {
        SaveData data = new SaveData();
        data.maxScore = maxScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // Write JSON to file
    }

    public void LoadNameAndScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            maxScore = data.maxScore;
        } else {
            playerName = "Player";
            maxScore = 0;
        }
    }
}