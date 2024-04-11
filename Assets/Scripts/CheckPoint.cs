using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D weiter) {

        if (weiter.tag == "Player") {

            RespawnController.instance.SetSpawn(transform.position);
        }
    }
}
