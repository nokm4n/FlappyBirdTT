using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn = 2f;
    [SerializeField] private float _range = .45f;
    [SerializeField] private float _timer = 0;

    [SerializeField, NotNull] Pipes _pipe;

    private bool _isGameover = false;

    public static List<Pipes> pipesList = new List<Pipes>();

	private void Awake()
	{
		SpawnPipe();
        //time and speed of pipes from prefs
        int difficulty = PlayerPrefs.GetInt("Difficulty");

        _timeToSpawn-=difficulty/3f;


		CEvents.OnGameOver += GameOver;
	}
	private void OnDisable()
	{
		CEvents.OnGameOver -= GameOver;
	}

    private void Update()
    {
        if (_isGameover) return;

        if(_timer > _timeToSpawn)
        {
            SpawnPipe();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_range, _range), 0);
        var pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        pipesList.Add(pipe);
    }

	private void GameOver()
	{
        _isGameover = true;
        if(pipesList != null)
        foreach (Pipes pipe in pipesList)
        {
            pipe.SetSpeed(0);
        }
	}
}
