using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAktiv : MonoBehaviour {

    public GameObject bossZuAktiv;

    private void OnTriggerEnter2D(Collider2D andere) {

        if(andere.tag == "Player") {
            bossZuAktiv.SetActive(true);

            gameObject.SetActive(false);
        }
    }

}
