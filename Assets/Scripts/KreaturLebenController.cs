using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KreaturLebenController : MonoBehaviour {

    public int ingesamtLeben = 3;

    public GameObject todEffekt;

    public void SchadeKreatur(int schadeMenge) {

        ingesamtLeben -= schadeMenge;

            if (ingesamtLeben <= 0) {
                
            if(todEffekt != null) {

                Instantiate(todEffekt, transform.position, transform.rotation);
            }
            Destroy(gameObject);

            AudioManager.instance.PlaySFXAdjusted(4);
        }
    }
}
