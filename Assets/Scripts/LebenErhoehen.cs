using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LebenErhoehen : MonoBehaviour {

    public int lebenAnzahl;

    public GameObject gegenstandEffekt;

    private void OnTriggerEnter2D(Collider2D weiter) {

        if(weiter.tag == "Player") {

            SpielerLebenController.instance.LebenSpieler(lebenAnzahl);

            if(gegenstandEffekt != null) {

                Instantiate(gegenstandEffekt, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);

            AudioManager.instance.PlaySFXAdjusted(5);
        }
    }

}
