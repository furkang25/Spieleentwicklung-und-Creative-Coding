using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.instance.LevelMusik1();
        AudioManager.instance.LevelMusik2();
        AudioManager.instance.LevelMusik3();
        AudioManager.instance.LevelMusik4();
        AudioManager.instance.SoundOff();
    }
}
