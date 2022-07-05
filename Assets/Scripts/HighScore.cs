using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScore : MonoBehaviour
{
	public static HighScore Instance;
	public string CurrentName;
	public string HighscoreName;
	public int Score = 0;
	private void Awake()
	{
		if(Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
	public void CompareScore(int score)
	{
		if (score > Score)
		{
			HighscoreName = CurrentName;
			Score = score;
			SaveHighscore();
		}
	}

	[System.Serializable]
	class SaveData
	{
		public string HighscoreName;
		public int Score;
	}
	public void SaveHighscore()
	{
		SaveData data = new SaveData();
		data.HighscoreName = HighscoreName;
		data.Score = Score;

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
	}
	public void LoadHighscore()
	{
		string path = Application.persistentDataPath + "/highscore.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);
			HighscoreName = data.HighscoreName;
			Score = data.Score;
		}
	}
}
