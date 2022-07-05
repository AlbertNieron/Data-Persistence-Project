using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
	[SerializeField] private TMP_InputField _EnterName;
	public void LoadAnotherScene()
	{
		if(SceneManager.GetActiveScene().buildIndex == 0)
		{
			SceneManager.LoadScene(1);
		}
		else
		{
			SceneManager.LoadScene(0);
		}
	}
	public void SaveCurrentName()
	{
		string currentName = _EnterName.text;
		HighScore.Instance.CurrentName = currentName;
	}
	public void ExitGame()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}
}
