using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraController : MonoBehaviour {
    
    private SpielerController spieler;
    public BoxCollider2D grenzeBox;

    private float halfHeight, halfWidth;

    // Start is called before the first frame update
    void Start() {
        spieler = FindObjectOfType<SpielerController>();

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        AudioManager.instance.LevelMusik2();
    }

    // Update is called once per frame
    void Update() {
        if(spieler != null) {
            transform.position = new Vector3(
                Mathf.Clamp(spieler.transform.position.x, grenzeBox.bounds.min.x + halfWidth, grenzeBox.bounds.max.x - halfWidth),
                Mathf.Clamp(spieler.transform.position.y, grenzeBox.bounds.min.y + halfHeight, grenzeBox.bounds.max.y - halfHeight),
                transform.position.z);
        }
    }
}
