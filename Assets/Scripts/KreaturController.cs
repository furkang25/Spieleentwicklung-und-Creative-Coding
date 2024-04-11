using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KreaturController : MonoBehaviour
{
    public      Transform[]     patrolPunkt;
    private     int             aktuellenPunkt;

    public      float           bewegungGeschwindigkeit, wartenAufPunkte;
    private     float           wartenTimer;

    public      float           springeForce;

    public      Rigidbody2D     rigidbody2D;
    public      Animator        animator;

    // Start is called before the first frame update
    void Start() {
        wartenTimer = wartenAufPunkte;

        foreach (Transform pPunkt in patrolPunkt) {

            pPunkt.SetParent(null);
            
        }
    }

    // Update is called once per frame
    void Update() {
        
        if (Mathf.Abs(transform.position.x - patrolPunkt[aktuellenPunkt].position.x) > .2f) {

            if (transform.position.x < patrolPunkt[aktuellenPunkt].position.x) {

                rigidbody2D.velocity = new Vector2(bewegungGeschwindigkeit, rigidbody2D.velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            } else {
                
                rigidbody2D.velocity = new Vector2(-bewegungGeschwindigkeit, rigidbody2D.velocity.y);
                transform.localScale = Vector3.one;
            }

            if (transform.position.y < patrolPunkt[aktuellenPunkt].position.y -.5f && rigidbody2D.velocity.y < .1f) {

                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, springeForce);
            }
        } else {

                rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);

                wartenTimer -= Time.deltaTime;

                if (wartenTimer <= 0) {

                    wartenTimer = wartenAufPunkte;

                    aktuellenPunkt++;

                    if (aktuellenPunkt >= patrolPunkt.Length) {

                        aktuellenPunkt = 0;
                }
            } 
        }

        animator.SetFloat("Geschwindigkeit", Mathf.Abs(rigidbody2D.velocity.x));
    }
}