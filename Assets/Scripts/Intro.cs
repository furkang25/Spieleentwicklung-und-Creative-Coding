using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    public float wait = 5f;

    void Start() {

        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro() {

        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene(2);
    }

    }