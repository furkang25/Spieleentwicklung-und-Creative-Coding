using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Einleitung : MonoBehaviour {

    public GameObject einleitung;

    public void Einleitungen() {

        if (!einleitung.activeSelf) {

            einleitung.SetActive(true);

            Time.timeScale = 0f;
        }
        else {
            einleitung.SetActive(false);

            Time.timeScale = 1f;
        }
    }
}
