using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour {

    // public PlayerController PlayerOne, PlayerTwo;
    public static PlayerController p1, p2;

    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        p1 = GameObject.Find("Player One").GetComponent<PlayerController>();
        p2 = GameObject.Find("Player Two").GetComponent<PlayerController>();
        // p2.enabled = false;
        // Debug.Log(p2.name);
    }

    public static void SwitchPlayers(PlayerFilter _filter)
    {
        if (_filter == PlayerFilter.PLAYER_ONE)
        {
            p2.enabled = true;
            p1.enabled = false;
        }
        else
        {
            p1.enabled = true;
            p2.enabled = false;
        }
    }
}
