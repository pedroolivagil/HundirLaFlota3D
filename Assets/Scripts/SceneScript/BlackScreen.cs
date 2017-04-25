using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour {

    public Slider sliderLoader;
    public AsyncOperation loadScene;

    // Use this for initialization
    void Start() {
        //StartCoroutine(PreLoadScene());
        sliderLoader.value = 0;
        loadScene = SceneManager.LoadSceneAsync(GameScenes.StarterSinglePlayer);
    }

    // Update is called once per frame
    void Update() {
        PreLoadScene();
    }

    private void PreLoadScene() {
        while (sliderLoader.value < 100) {
            //yield return new WaitForSeconds(Random.Range(.05f,.3f));
            Debug.Log("Preload scene progress: " + loadScene.progress * 100);
            sliderLoader.value = loadScene.progress * 100;
        }
    }

    public void FinishPreLoad() {
        if (sliderLoader != null) {
            if (loadScene.isDone) {
                Debug.Log("Finish Loading");
                if (GameManager.GetGameMode() == GameManager.SINGLE_PLAYER) {
                    GameManager.ChangeScreen(GameScenes.StarterSinglePlayer);
                } else {
                    // cambiar por la pantalla de multijugador
                    GameManager.ChangeScreen(GameScenes.MainMenuScene);
                }
            }
        }
    }
}
