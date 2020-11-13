using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {//prevents double spawns and overlaps
        if (other.CompareTag("sideroom")) {
            Destroy(other.gameObject);
        }
    }
}
