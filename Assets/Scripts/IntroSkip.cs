using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSkip : MonoBehaviour {

    void Start() {

        AudioManager.instance.SoundOff();
    }

    public string loadScene;

    public void skip() {

        Time.timeScale = 1f;

        SceneManager.LoadScene(loadScene);
    }

}
