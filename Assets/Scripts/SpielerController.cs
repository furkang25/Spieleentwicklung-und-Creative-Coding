using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerController : MonoBehaviour {

    public      Rigidbody2D     rigidbody2D;

    public      float           bewegungsgeschwindigkeit;
    public      float           sprungkraft;

    public      Transform       bodenPunkt;
    private     bool            derRichtigBoden;
    public      LayerMask       derBoden;

    public      Animator        animator;

    public      FeuerController feuerController;
    public      Transform       feuerPunkt;

    public      bool            doubleSpringe;

    public      float           dashGeschwindigkeit, dashZeit;
    private     float           dashTimer;

    public      SpriteRenderer  derDash, spaeterBild;
    public      float           spaeterBildLebenszeit, zeitdanachBild;
    private     float           spaeterBildTimer;
    private     Color           spaeterBildColor;

    private     float           pauseSpaeterDashing;
    private     float           dashAufladenTimer;

    private SpielerFaehigkeit faehigkeit;

    public bool kannBewegung;

    void Start() {

        faehigkeit = GetComponent<SpielerFaehigkeit>();

        kannBewegung = true;
    }

    void Update() {

        if (kannBewegung && Time.timeScale != 0) {

        if (dashAufladenTimer > 0) {

            dashAufladenTimer -= Time.deltaTime;

        } else {


        if (Input.GetButtonDown("Fire2") && faehigkeit.dash ) {

            dashTimer = dashZeit;

            SchauSpaeterBild();

            AudioManager.instance.PlaySFXAdjusted(6);
        }
    }

        if (dashTimer > 0) {

            dashTimer = dashTimer - Time.deltaTime;

            rigidbody2D.velocity = new Vector2(dashGeschwindigkeit * transform.localScale.x, rigidbody2D.velocity.y);


            spaeterBildTimer -= Time.deltaTime;

            if (spaeterBildTimer <= 0) {
                SchauSpaeterBild();
            }

            dashAufladenTimer = pauseSpaeterDashing;
        } else {
        
        // Bewegung
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * bewegungsgeschwindigkeit, rigidbody2D.velocity.y);

        // Zurück bewegung
        if (rigidbody2D.velocity.x < 0) {
            
            transform.localScale = new Vector3(-1f, 1f, 1f);

        } else if (rigidbody2D.velocity.x > 0) {
            
            transform.localScale = Vector3.one;
        }
        }

        // Check ob der Richtig Boden ist
        derRichtigBoden = Physics2D.OverlapCircle(bodenPunkt.position, .2f, derBoden);

        // Springen
        if (Input.GetButtonDown("Jump") && (derRichtigBoden || (doubleSpringe && faehigkeit.doubleSpringe))) {
            
            if (derRichtigBoden) {

                doubleSpringe = true;

                AudioManager.instance.PlaySFXAdjusted(9);

            } else {

                doubleSpringe = false;

                animator.SetTrigger("doubleSpringe");

                AudioManager.instance.PlaySFXAdjusted(8);
            }

            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, sprungkraft);
        }

        // Feuren
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(feuerController, feuerPunkt.position, feuerPunkt.rotation).bewegung = new Vector2(transform.localScale.x, 0f);
            
            animator.SetTrigger("feuer");

            AudioManager.instance.PlaySFXAdjusted(10);
        }
        } else {

            rigidbody2D.velocity = Vector2.zero;
        }

        animator.SetBool("derBoden", derRichtigBoden);
        animator.SetFloat("Geschwindigkeit", Mathf.Abs(rigidbody2D.velocity.x));
    }

    public void SchauSpaeterBild() {

        SpriteRenderer bild = Instantiate(spaeterBild, transform.position, transform.rotation);
        bild.sprite = derDash.sprite;
        bild.transform.localScale = transform.localScale;
        bild.color = spaeterBildColor;

        Destroy(bild.gameObject, spaeterBildLebenszeit);

        spaeterBildTimer = zeitdanachBild;
    }
    }