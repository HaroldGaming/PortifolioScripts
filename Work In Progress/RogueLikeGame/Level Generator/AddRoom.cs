﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour{

    private RoomTemplates templates;

    private void Start() {//adds itself to the roomList so the RoomTemple can keep track of it.
        templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

}