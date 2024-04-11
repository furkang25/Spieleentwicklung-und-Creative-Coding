using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public static UIController instance;

    public string menusehen;

    public GameObject pauseSzene;

    private void Awake() {

        if (instance == null) {

            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {

            Destroy(gameObject);
        }
    }

    public Slider lebenSlider;

    public Image loadScene;

    public float verblassenGeschwindigkeit = 2f;
    private bool verblassenZurueck, verblassenForm;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
        if (verblassenZurueck) {

            loadScene.color = new Color(loadScene.color.r, loadScene.color.g, loadScene.color.b, Mathf.MoveTowards(loadScene.color.a, 1f, verblassenGeschwindigkeit * Time.deltaTime));

            if (loadScene.color.a == 1f) {

                verblassenZurueck = false;
            }
        } else if (verblassenForm) {

            loadScene.color = new Color(loadScene.color.r, loadScene.color.g, loadScene.color.b, Mathf.MoveTowards(loadScene.color.a, 0f, verblassenGeschwindigkeit * Time.deltaTime));

            if (loadScene.color.a == 0f) {

                verblassenForm = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseUnpause();
        }
    }

    public void UpdateLeben(int aktuellesLeben, int maxLeben) {

        lebenSlider.maxValue = maxLeben;
        lebenSlider.value = aktuellesLeben;
    }

    public void StartLoadScreen1() {

        verblassenZurueck = true;
        verblassenForm = false;
    }

    public void StartLoadScreen2() {

        verblassenForm = true;
        verblassenZurueck = false;
    }

    public void PauseUnpause() {

        if (!pauseSzene.activeSelf) {

            pauseSzene.SetActive(true);

            Time.timeScale = 0f;
        }
        else {
            pauseSzene.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    public void zurueckMenu() {

        Time.timeScale = 1f;

        Destroy(SpielerLebenController.instance.gameObject);

        SpielerLebenController.instance = null;

        Destroy(RespawnController.instance.gameObject);
        RespawnController.instance = null;

        instance = null;
        Destroy(gameObject);

        SceneManager.LoadScene(menusehen);
    }
}
