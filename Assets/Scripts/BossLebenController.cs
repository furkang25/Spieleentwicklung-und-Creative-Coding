using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLebenController : MonoBehaviour {

 public static BossLebenController instance;

    private void Awake() {

        instance = this;
    }

    public Slider bossLebenSlider;

    public int aktuellenLeben = 30;

    public BossKampf derBoss;

    void Start() {

        bossLebenSlider.maxValue = aktuellenLeben;
        bossLebenSlider.value = aktuellenLeben;
    }

    public void schadenNehmen(int schadenBetrag)
    {
        aktuellenLeben -= schadenBetrag;

        if(aktuellenLeben <= 0)
        {
            aktuellenLeben = 0;

            derBoss.EndKampf();

            AudioManager.instance.PlaySFX(0);
        }
        else {
            AudioManager.instance.PlaySFX(1);
        }

        bossLebenSlider.value = aktuellenLeben;
    }
}
