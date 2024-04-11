using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kreatur2Controller : MonoBehaviour {
    
    public       float           rangeToStartVerfolgung;
    private      bool            verfolgung;

    public       float           bewegungGeschwindigkeit, drehenGeschwindigkeit;

    private      Transform       spieler;

    public       Animator        animator;
    
    // Start is called before the first frame update
    void Start() {

        spieler = SpielerLebenController.instance.transform;
    }

    // Update is called once per frame
    void Update() {

        if(!verfolgung) {

        if(Vector3.Distance(transform.position, spieler.position) < rangeToStartVerfolgung) {

            verfolgung = true;

            animator.SetBool("verfolgung", verfolgung);
        }
    } else {

        if (spieler.gameObject.activeSelf) {

            Vector3 direction = transform.position - spieler.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, drehenGeschwindigkeit * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, spieler.position, bewegungGeschwindigkeit * Time.deltaTime);
        }
    }
    }
}
