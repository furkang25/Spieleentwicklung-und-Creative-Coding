using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerLebenController : MonoBehaviour {

    public static SpielerLebenController instance;

    private void Awake() {

        if (instance == null) {

        instance = this;
        DontDestroyOnLoad(gameObject);

        } else {
            Destroy(gameObject);
        }
    }

    //[HideInInspector]
    public int aktuellesLeben;
    public int maxLeben;

    public float unbesiegbarkeitLaenge;
    private float kostenZaehler;

    public float blitzLaenge;
    private float blitzZaehler;

    public SpriteRenderer[] spielerSprites;

    // Start is called before the first frame update
    void Start() {
        aktuellesLeben = maxLeben;

        //UIController.instance.UpdateLeben(aktuellesLeben, maxLeben);
    }

    // Update is called once per frame
    void Update() {
        
        if (kostenZaehler > 0) {

            kostenZaehler -= Time.deltaTime;

            blitzLaenge -= Time.deltaTime;

            if (blitzLaenge <= 0) {

                foreach (SpriteRenderer sr in spielerSprites)
                {
                    sr.enabled = !sr.enabled;
                }
                blitzZaehler = blitzLaenge;
            }
            if (kostenZaehler <= 0) {

                foreach (SpriteRenderer sr in spielerSprites) {

                    sr.enabled = true;
                }
                blitzZaehler = 0f;
            }
        }
    }

    public void SchadeSpieler(int schadeMenge) {

        if (kostenZaehler <= 0) {

        aktuellesLeben -= schadeMenge;

        if (aktuellesLeben <= 0) {

            aktuellesLeben = 0;

            //gameObject.SetActive(false);

            RespawnController.instance.Respawn();

            AudioManager.instance.PlaySFX(7);

        } else {
            kostenZaehler = unbesiegbarkeitLaenge;

            AudioManager.instance.PlaySFXAdjusted(11);
        }
        
        UIController.instance.UpdateLeben(aktuellesLeben, maxLeben);
        }
    }

    public void FillLeben() {

        aktuellesLeben = maxLeben;

        UIController.instance.UpdateLeben(aktuellesLeben, maxLeben);
    }

    public void LebenSpieler(int lebenAnzahl) {

        aktuellesLeben += lebenAnzahl;

        if (aktuellesLeben > maxLeben) {

            aktuellesLeben = maxLeben;
        }

        UIController.instance.UpdateLeben(aktuellesLeben, maxLeben);
    }
}
