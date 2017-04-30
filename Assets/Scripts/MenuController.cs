using UnityEngine;

public class MenuController : MonoBehaviour {

    public void ActionBtnSinglePlay() {
        Debug.Log("Play game");
        GameManager.ChangeScreen(GameScenes.StarterSinglePlayer, true);
    }

    public void ActionBtnMultiPlay() {
        //BlackScreen.SetNavigateScene(GameScenes.StarterMultiPlayer);
        //GameManager.ChangeScreen(GameScenes.BlackScreen);
        Debug.Log("Play Multiplayer");
    }

    public void ActionBtnSettings() {
        Debug.Log("Settings");
    }

    public void ActionBtnExit() {
        GameManager.ChangeScreen(GameScenes.ExitScreen);
    }
}
