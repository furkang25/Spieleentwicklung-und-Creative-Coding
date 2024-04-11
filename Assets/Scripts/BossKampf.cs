using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossKampf : MonoBehaviour {

    public static BossKampf instance;

    private KameraController derKamera;
    public Transform kameraPosition;
    public float kameraGeschwindigkeit;

    public int schwelle1, schwelle2;

    public float aktiveZeit, ausblendzeit, inaktiveZeit;
    private float aktivZaehler, fadeCounter, inaktiverZaehler;

    public Transform[] spawnPunkte;
    private Transform zielPunkt;
    public float bewegungsGeschwindigkeit;

    public Animator animator;

    public Transform derBoss;

    public float zeitZwischendenAufnahmen1, zeitZwischendenAufnahmen2;
    private float SchussZaehler;
    public GameObject patrone;
    public Transform schussPunkt;

    private bool kampfEnde;

    public string loadScene;

    public string bossRef;

    void Start() {

        derKamera = FindObjectOfType<KameraController>();

        derKamera.enabled = false;

        aktivZaehler = aktiveZeit;

        SchussZaehler = zeitZwischendenAufnahmen1;

        AudioManager.instance.LevelMusik4();
    }

    void Update() {

        derKamera.transform.position = Vector3.MoveTowards(derKamera.transform.position, kameraPosition.position, kameraGeschwindigkeit * Time.deltaTime);

        if(!kampfEnde) {

        if (BossLebenController.instance.aktuellenLeben > schwelle1) {

            if (aktivZaehler > 0) {

                aktivZaehler -= Time.deltaTime;

                if (aktivZaehler <= 0) {

                    fadeCounter = ausblendzeit;

                    animator.SetTrigger("vanish");
                }

                SchussZaehler -= Time.deltaTime;

                    if (SchussZaehler <= 0) {

                        SchussZaehler = zeitZwischendenAufnahmen1;

                        Instantiate(patrone, schussPunkt.position, Quaternion.identity);
                    }
            }
            else if (fadeCounter > 0) {

                fadeCounter -= Time.deltaTime;

                if (fadeCounter <= 0) {

                    derBoss.gameObject.SetActive(false);

                    inaktiverZaehler = inaktiveZeit;
                }
            }
            else if (inaktiverZaehler > 0) {

                inaktiverZaehler -= Time.deltaTime;
                
                if (inaktiverZaehler <= 0){

                    derBoss.position = spawnPunkte[Random.Range(0, spawnPunkte.Length)].position;
                    derBoss.gameObject.SetActive(true);

                    aktivZaehler = aktiveZeit;

                    SchussZaehler = zeitZwischendenAufnahmen1;
                }
            }
            else {

                if (zielPunkt == null) {

                    zielPunkt = derBoss;

                    fadeCounter = ausblendzeit;

                    animator.SetTrigger("vanish");
                }

                else {

                    if (Vector3.Distance(derBoss.position, zielPunkt.position) > .02f) {

                        derBoss.position = Vector3.MoveTowards(derBoss.position, zielPunkt.position, bewegungsGeschwindigkeit * Time.deltaTime);

                if (Vector3.Distance(derBoss.position, zielPunkt.position) <= .02f) {
                    
                    fadeCounter = ausblendzeit;
                    animator.SetTrigger("vanish");
                }

                SchussZaehler -= Time.deltaTime;

                    if (SchussZaehler <= 0) {

                        if (SpielerLebenController.instance.aktuellesLeben > schwelle2) {

                            SchussZaehler = zeitZwischendenAufnahmen1;

                        } else {

                            SchussZaehler = zeitZwischendenAufnahmen2;
                        }

                        Instantiate(patrone, schussPunkt.position, Quaternion.identity);
                    }
            }
            else if (fadeCounter > 0) {

                fadeCounter -= Time.deltaTime;

                if (fadeCounter <= 0) {

                    derBoss.gameObject.SetActive(false);
                    inaktiverZaehler = inaktiveZeit;
                }
            }
            else if (inaktiverZaehler > 0) {

                inaktiverZaehler -= Time.deltaTime;

                if (inaktiverZaehler <= 0) {

                    derBoss.position = spawnPunkte[Random.Range(0, spawnPunkte.Length)].position;
                    
                    zielPunkt = spawnPunkte[Random.Range(0, spawnPunkte.Length)];

                    int whileBreaker = 0;

                            while (zielPunkt.position == derBoss.position && whileBreaker < 100)
                            {
                                zielPunkt = spawnPunkte[Random.Range(0, spawnPunkte.Length)];

                                whileBreaker++;
                            }

                    derBoss.gameObject.SetActive(true);

                    if (SpielerLebenController.instance.aktuellesLeben > schwelle2) {

                            SchussZaehler = zeitZwischendenAufnahmen1;

                        } else {

                            SchussZaehler = zeitZwischendenAufnahmen2;
                        }
                    }
                }
                }
            }
        }
    } else {

        fadeCounter -= Time.deltaTime;

        if(fadeCounter < 0) {
            if(loadScene  != null) {
                
                SceneManager.LoadScene(loadScene);
            }

                gameObject.SetActive(false);
                PlayerPrefs.SetInt(bossRef, 1);
            }
        }
    }

    public void EndKampf() {
        kampfEnde = true;

        fadeCounter = ausblendzeit;
        animator.SetTrigger("vanish");
        derBoss.GetComponent<Collider2D>().enabled = false;

        BossFeuer[] bullets = FindObjectsOfType<BossFeuer>();

        if(bullets.Length > 0) {

            foreach(BossFeuer bb in bullets) {

                Destroy(bb.gameObject);
            }
        }
    }
}
