using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	[SerializeField, NotNull] private TextMeshProUGUI _scoreText;
	[SerializeField, NotNull] private TextMeshProUGUI _loseScoreText;
	[SerializeField, NotNull] private TextMeshProUGUI _bestScoreText;

	private int _score = 0;

	public static Score instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("there is more than 1 GameManager");
		}
		instance = this;

		if (!PlayerPrefs.HasKey("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", 0);
			_bestScoreText.text = "Best: 0";
		}
		else
		{
			_bestScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore").ToString();

		}
		_scoreText.text = "Score: " + _score.ToString();

		CEvents.OnGameOver += GameOver;
	}

	private void OnDisable()
	{
		CEvents.OnGameOver -= GameOver;
	}

	public void AddScore()
	{
		_score++;
		_scoreText.text = "Score: " + _score.ToString();
	}

	private void GameOver()
	{
		_loseScoreText.text = "Your score: " + _score.ToString();
		if (_score > PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", _score);
		}
	}

}
