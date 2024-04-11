using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainManu : MonoBehaviour {

    public static LoadMainManu instance;

    public float wait = 5f;

    void Start() {

        StartCoroutine(Wait_for_main());
    }

    IEnumerator Wait_for_main() {

        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene(0);
        //skip();
    }


    void skip() {

        Destroy(SpielerLebenController.instance.gameObject);

        SpielerLebenController.instance = null;

        Destroy(RespawnController.instance.gameObject);
        RespawnController.instance = null;

        instance = null;
        Destroy(gameObject);
    }

    }
