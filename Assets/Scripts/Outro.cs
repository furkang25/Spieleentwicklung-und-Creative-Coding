using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Outro : MonoBehaviour {
    public float wait = 5f;

    void Start() {

        StartCoroutine(Wait_for_outro());
    }

    IEnumerator Wait_for_outro() {

        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene(7);
    }

    }