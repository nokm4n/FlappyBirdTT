using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField, NotNull] private AudioSource _bgMusic;

    private float _speed = 1f;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("there is more than 1 GameManager");
        }
        instance = this;
        if (PlayerPrefs.HasKey("Music"))
            _bgMusic.enabled = Convert.ToBoolean(PlayerPrefs.GetInt("Music"));
        else
            _bgMusic.enabled = true;
        // Time.timeScale = 1f;

    }
	public float GetSpeed()
    {
        //playerPrefs
        return _speed;
    }



}
