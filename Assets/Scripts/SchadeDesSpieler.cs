using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchadeDesSpieler : MonoBehaviour {

    public int schadeMenge = 1;

    public bool zerstorungSchade;
    public GameObject zerstorungEffekt;

    private void OnCollisionEnter2D(Collision2D weiter) {

        if (weiter.gameObject.tag == "Player") {

            HandelnSchade();
        }

    }

    private void OnTriggerEnter2D(Collider2D weiter) {

        if (weiter.tag == "Player") {

            HandelnSchade();
        }
    }

    void HandelnSchade() {

        SpielerLebenController.instance.SchadeSpieler(schadeMenge);

        if (zerstorungSchade) {

            if (zerstorungEffekt != null) {

                Instantiate(zerstorungEffekt, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }

}
