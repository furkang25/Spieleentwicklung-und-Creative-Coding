using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entscheidung : MonoBehaviour {

    public string loadScene1;
    public string loadScene2;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.SoundOff();
    }

    public void Vengeance() {

        Time.timeScale = 1f;

        SceneManager.LoadScene(loadScene1);
    }

    public void Forgiveness() {

        Time.timeScale = 1f;

        SceneManager.LoadScene(loadScene2);
    }
}
