using System;
using System.IO;
using UnityEngine;

public class PlayerConfig
{
	private const string fileName = "config.json";

	public int version = 1;
	public float mouseSensitivity = 0.05f;

	public static PlayerConfig Load()
	{
		string configPath = Path.Combine(Application.persistentDataPath, fileName);
		if (!File.Exists(configPath)) return null;

		string stringContents = File.ReadAllText(configPath);
		return JsonUtility.FromJson<PlayerConfig>(stringContents);
	}

	public static void Save(PlayerConfig parsedContents)
	{
		string configPath = Path.Combine(Application.persistentDataPath, fileName);
		string stringContents = JsonUtility.ToJson(parsedContents, true);
		File.WriteAllText(configPath, stringContents);
	}
}
