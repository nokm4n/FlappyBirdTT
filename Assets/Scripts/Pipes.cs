using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    private float _speed;

    [SerializeField, NotNull] private GameObject _pipe0;
    [SerializeField, NotNull] private GameObject _pipe1;

	private void Start()
    {
		_speed = GameManager.instance.GetSpeed();
		int difficulty = PlayerPrefs.GetInt("Difficulty");

        float range = (2f - difficulty) / 3;
        _pipe0.transform.position = new Vector3(_pipe0.transform.position.x, _pipe0.transform.position.y + Random.Range(0, range), _pipe0.transform.position.z);
        _pipe1.transform.position = new Vector3(_pipe1.transform.position.x, _pipe1.transform.position.y - Random.Range(0, range), _pipe1.transform.position.z);
	}

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * _speed;

        if(transform.position.x < -2)
        {
            PipeSpawner.pipesList.Remove(this);
            Destroy(gameObject);
        }
    }

	public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
