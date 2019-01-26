﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static bool Paused;

    // us Game.Player to get currently active player.
    private static Player _player;
    private static Stargate _stargate;
    public static Player Player
    {
        get
        {
            if (_player == null) { _player = GameObject.FindObjectOfType<Player>(); }
            return _player;
        }
    }

    public static Vector3 PlayerPosition
        => Player?.transform.position ?? Vector3.zero;

    public static Stargate Stargate
    {
        get
        {
            if (_stargate == null) { _stargate = GameObject.FindObjectOfType<Stargate>(); }
            return _stargate;
        }
    }

    // us Game.Player to get currently active camera.
    private static Camera _camera;
    public static Camera Camera
    {
        get
        {
            if (_camera == null) { _camera = Camera.main; }
            return _camera;
        }
    }

	public static Vector3 MousePosition
    {
        get
        {
            var ray = Camera.ScreenPointToRay(Input.mousePosition);
            return new Vector3(ray.origin.x, ray.origin.y, 0);
        }
    }

    public static Vector3 RandomDirection()
        => new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
}