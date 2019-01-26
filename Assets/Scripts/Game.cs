using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    // us Game.Player to get currently active player.
    private static Player _player;
    public static Player Player
    {
        get
        {
            if (_player == null) { _player = GameObject.FindObjectOfType<Player>(); }
            return _player;
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
}