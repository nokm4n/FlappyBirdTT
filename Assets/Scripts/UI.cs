using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField, NotNull] private GameObject _gameOverCanv;
    [SerializeField, NotNull] private GameObject _gameplayCanv;

	private void Awake()
    {
        _gameplayCanv.transform.DOScale(Vector3.one, 0);
		_gameOverCanv.transform.DOScale(Vector3.zero, 0);

        CEvents.OnGameOver += GameOver;

	}
    private void OnDisable()
    {
		CEvents.OnGameOver -= GameOver;
	}

    private void GameOver()
    {
		_gameplayCanv.transform.DOScale(Vector3.zero, 0);
		_gameOverCanv.transform.DOScale(Vector3.one, 1);
	}

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
