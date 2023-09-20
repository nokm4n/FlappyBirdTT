using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
	private int _difficulty = 0;
	[SerializeField, NotNull] private GameObject _mainCanv;
	[SerializeField, NotNull] private GameObject _settingsCanv;

	[SerializeField, NotNull] private TextMeshProUGUI _currentDifficulty;

	[SerializeField, NotNull] private Toggle _musicToggle;
	[SerializeField, NotNull] private Toggle _effectsToggle;

	private void Awake()
	{
		if (PlayerPrefs.HasKey("Difficulty"))
		{
			_difficulty = PlayerPrefs.GetInt("Difficulty");
			_currentDifficulty.text = "Current difficulty is: " + PlayerPrefs.GetInt("Difficulty").ToString();
		}
		else
		{
			_currentDifficulty.text = "Current difficulty is: " + 0;
			PlayerPrefs.SetInt("Difficulty", 0);
		}

		if (PlayerPrefs.HasKey("Music"))
			_musicToggle.isOn = Convert.ToBoolean( PlayerPrefs.GetInt("Music"));
		else
		{
			PlayerPrefs.SetInt("Music", Convert.ToInt16(1));
			_musicToggle.isOn = true;
		}

		if (PlayerPrefs.HasKey("Effects"))
			_effectsToggle.isOn = Convert.ToBoolean( PlayerPrefs.GetInt("Effects"));
		else
		{
			PlayerPrefs.SetInt("Effects", Convert.ToInt16(1));
			_effectsToggle.isOn = true;
		}
		OnMenu();
		PlayerPrefs.Save();
	}
	public void PlayButton()
    {
		SetDifficulty(_difficulty);
		SceneManager.LoadScene(1);
	}

	public void SetDifficulty(int difficulty)
	{
		PlayerPrefs.SetInt("Difficulty", difficulty);
		_difficulty = difficulty;
		_currentDifficulty.text = "Current difficulty is: " + PlayerPrefs.GetInt("Difficulty").ToString();
		PlayerPrefs.Save();
	}

	public void OnSettings()
	{
		_difficulty = PlayerPrefs.GetInt("Difficulty");
		_currentDifficulty.text = "Current difficulty is: " + _difficulty;

		_settingsCanv.transform.DOScale(Vector3.one, 1);
		_mainCanv.transform.DOScale(Vector3.zero, 1);
	}

	public void OnMenu()
	{
		_mainCanv.transform.DOScale(Vector3.one, 1);
		_settingsCanv.transform.DOScale(Vector3.zero, 0);
	}
	public void ToggleMusic(bool musicToggle)
	{
		Debug.Log(musicToggle + " " + Convert.ToInt16(musicToggle));
		PlayerPrefs.SetInt("Music", Convert.ToInt16(musicToggle));
		PlayerPrefs.Save();
	}
	public void ToggleEffects(bool effectsToggle)
	{
		Debug.Log(effectsToggle + " " + Convert.ToInt16(effectsToggle));
		PlayerPrefs.SetInt("Effects", Convert.ToInt16(effectsToggle));
		PlayerPrefs.Save();
	}
}
