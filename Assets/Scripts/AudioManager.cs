using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    private void Awake() {

        if (instance == null) {

            instance = this;

            //DontDestroyOnLoad(gameObject);
            
        } else {

            Destroy(gameObject);
        }
    }

    public AudioSource levelMusik1, levelMusik2, levelMusik3, levelMusik4;

    public AudioSource[] sfx;

    public void LevelMusik1() {

        levelMusik2.Stop();
        levelMusik3.Stop();
        levelMusik4.Stop();

        levelMusik1.Play();
    }

    public void LevelMusik2() {
        
        levelMusik1.Stop();
        levelMusik3.Stop();
        levelMusik4.Stop();

        levelMusik2.Play();
    }

    public void LevelMusik3() {

        if (!levelMusik3.isPlaying) {

            levelMusik1.Stop();
            levelMusik2.Stop();
            levelMusik4.Stop();

            levelMusik3.Play();
        }
    }

    public void LevelMusik4() {
        
        levelMusik1.Stop();
        levelMusik2.Stop();
        levelMusik3.Stop();

        levelMusik4.Play();
    }

    public void SoundOff() {

        levelMusik1.Stop();
        levelMusik2.Stop();
        levelMusik3.Stop();
        levelMusik4.Stop();
        
    }

    public void PlaySFX(int sfxPlay) {

        sfx[sfxPlay].Stop();
        sfx[sfxPlay].Play();
    }

    public void PlaySFXAdjusted(int sfxAdjusted) {

        sfx[sfxAdjusted].pitch = Random.Range(.8f, 1.2f);

        PlaySFX(sfxAdjusted);
    }
}
