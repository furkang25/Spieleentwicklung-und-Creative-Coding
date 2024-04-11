using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour {

    public static RespawnController instance;

    private void Awake() {

        if (instance == null) {

        instance = this;
        DontDestroyOnLoad(gameObject);

        } else {
            Destroy(gameObject);
        }
    }

    private Vector3 respawnPunkt;
    public float pauseZuRespawn;

    private GameObject derSpieler;

    public GameObject todEffekt;


    // Start is called before the first frame update
    void Start()
    {
        derSpieler = SpielerLebenController.instance.gameObject;

        respawnPunkt = derSpieler.transform.position;
    }

    public void SetSpawn(Vector3 neuePosition) {

        respawnPunkt = neuePosition;
    }

    public void Respawn() {

        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo() {

        derSpieler.SetActive(false);
        
        if (todEffekt != null) {

            Instantiate(todEffekt, derSpieler.transform.position, derSpieler.transform.rotation);
        }

        yield return new WaitForSeconds(pauseZuRespawn);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        derSpieler.transform.position = respawnPunkt;
        derSpieler.SetActive(true);

        SpielerLebenController.instance.FillLeben();
    }
}
