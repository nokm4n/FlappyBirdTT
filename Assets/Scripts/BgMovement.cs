using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovement : MonoBehaviour
{
    [SerializeField, NotNull] private MeshRenderer _mesRenderer;

    private float _speed = .5f;
    private Vector2 _meshOffset;
	private void Awake()
	{
		_meshOffset = _mesRenderer.sharedMaterial.mainTextureOffset;
		CEvents.OnGameOver += GameOver;
	}

    private void OnDisable()
    {
        _mesRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
		CEvents.OnGameOver -= GameOver;
	}

    private void GameOver()
    {
        _speed = 0;
    }

    private void Update()
    {
        var x = Mathf.Repeat(Time.time * _speed, 1);
        var offset = new Vector2(x, _meshOffset.y);

        _mesRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}
