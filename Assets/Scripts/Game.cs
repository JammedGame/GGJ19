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
}