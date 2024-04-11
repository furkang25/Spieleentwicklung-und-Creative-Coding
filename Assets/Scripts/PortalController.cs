using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour {

    public float enfernungZuOeffnen;

    private SpielerController derSpieler;

    private bool spielerAusgang;

    public Transform ausgangPunkt;

    public float bewegungSpielerGeschwindkeit;

    public string levelToLaden;

    // Start is called before the first frame update
    void Start()
    {
        derSpieler = SpielerLebenController.instance.GetComponent<SpielerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spielerAusgang) {
            derSpieler.transform.position = Vector3.MoveTowards(derSpieler.transform.position, ausgangPunkt.position, bewegungSpielerGeschwindkeit * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D andere) {

        if(andere.tag ==  "Player") {

            if(!spielerAusgang) {

                derSpieler.kannBewegung = false;

                StartCoroutine(UseDoorCo());
        }
    }
}

    IEnumerator UseDoorCo() {

        spielerAusgang = true;

        UIController.instance.StartLoadScreen1();

        yield return new WaitForSeconds(1.5f);

        RespawnController.instance.SetSpawn(ausgangPunkt.position);

        derSpieler.kannBewegung = true;

        UIController.instance.StartLoadScreen2();

        SceneManager.LoadScene(levelToLaden);

}
}
