using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{

    public int level;
    public int health;

    public PlayerData (Player player) {//player data used for saving
        level = player.level;
        health = player.health;
    }
   
}
