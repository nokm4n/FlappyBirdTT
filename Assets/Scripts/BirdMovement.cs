using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
	[SerializeField] private float _velocity = 1f;
	[SerializeField] private float _rotSpeed = 10f;
	[SerializeField, NotNull] private AudioSource _jumpEffect;

	private Rigidbody2D _rb;
	private Animator _anim;
	private bool _isGameover = false;
	private bool _effectsOn = true;


	private void Awake()
	{
		if (!TryGetComponent(out _rb))
		{
			Debug.LogError("No rb attached to bird");
		}
		if (!TryGetComponent(out _anim))
		{
			Debug.LogError("No Animator attached to bird");
		}
		CEvents.OnGameOver += GameOver;

		_effectsOn = Convert.ToBoolean(PlayerPrefs.GetInt("Effects"));
	}
	private void OnDisable()
	{
		CEvents.OnGameOver -= GameOver;
	}

	private void GameOver()
	{
		_isGameover = true;
	}

	private void Update()
	{
		if (_isGameover) return;
		if(Input.GetMouseButtonDown(0))
		{
			if(_effectsOn)
			_jumpEffect.Play();


			_rb.velocity = Vector2.up * _velocity;
		}

		transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotSpeed);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		CEvents.FireGameOver();
		_anim.enabled = false;
	}
}
