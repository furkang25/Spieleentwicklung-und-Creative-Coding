using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FaehigkeitOpen : MonoBehaviour {

    public bool openDoubleSpringe, openDash;

    public GameObject openEffekt;

    public string openMitteilung;
    public TMP_Text openText;

    private void OnTriggerEnter2D(Collider2D mehr) {

        if(mehr.tag == "Player") {
            SpielerFaehigkeit spieler = mehr.GetComponentInParent<SpielerFaehigkeit>();

            if (openDoubleSpringe) {
                spieler.doubleSpringe = true;
            }

            if (openDash) {
                spieler.dash = true;
            }

            Instantiate(openEffekt, transform.position, transform.rotation);

            openText.transform.parent.SetParent(null);
            openText.transform.parent.position = transform.position;

            openText.text = openMitteilung;
            openText.gameObject.SetActive(true);

            Destroy(openText.transform.parent.gameObject, 5f);

            Destroy(gameObject);

            AudioManager.instance.PlaySFXAdjusted(5);
        }
    }

}
