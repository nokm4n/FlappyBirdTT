using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEvents : MonoBehaviour
{
    public static event Action OnGameOver;
    public static void FireGameOver() => OnGameOver?.Invoke();

}
