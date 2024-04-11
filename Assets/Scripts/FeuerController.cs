using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeuerController : MonoBehaviour {

    public float feuerGeschwindigkeit;
    public Rigidbody2D rigidbody2D;

    public Vector2 bewegung;

    public GameObject einschlagEffekt;

    public int schadenMenge = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = bewegung * feuerGeschwindigkeit;
    }

    private void OnTriggerEnter2D(Collider2D weiter) {

        if (weiter.tag == "Kreatur") {

            weiter.GetComponent<KreaturLebenController>().SchadeKreatur(schadenMenge);
        }
        
        if (weiter.tag == "Boss") {

            BossLebenController.instance.schadenNehmen(schadenMenge);
        }

        if(einschlagEffekt != null) {
            Instantiate(einschlagEffekt, transform.position, Quaternion.identity);
        }

        AudioManager.instance.PlaySFXAdjusted(3);

        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
