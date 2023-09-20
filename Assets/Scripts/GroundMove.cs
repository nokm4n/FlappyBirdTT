using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    private float _width = 3.12f;

    private float _speed;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _startSize;

	private void Awake()
	{
		CEvents.OnGameOver += GameOver;
	}
	private void OnDisable()
	{
		CEvents.OnGameOver -= GameOver;
	}
	private void Start()
    {
		if (!TryGetComponent(out _spriteRenderer))
		{
			Debug.LogError("No SpriteRenderer attached to Ground");
		}

        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);

        _speed = GameManager.instance.GetSpeed();
	}
   

	private void Update()
    {
		_spriteRenderer.size = new Vector2(_spriteRenderer.size.x + _speed * Time.deltaTime, _spriteRenderer.size.y);

        if(_spriteRenderer.size.x > _width)
        {
            _spriteRenderer.size = _startSize;
        }

		//transform.position += Vector3.left * Time.deltaTime * _speed;
	}

    private void GameOver()
    {
        _speed = 0;
    }
}
