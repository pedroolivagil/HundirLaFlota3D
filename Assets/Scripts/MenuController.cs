using UnityEngine;

public class MenuController : MonoBehaviour {

    public void ActionBtnSinglePlay() {
        Debug.Log("Play game");
        GameManager.SetGameMode(GameManager.SINGLE_PLAYER);
        GameManager.ChangeScreen(GameScenes.BlackScreen);
    }

    public void ActionBtnMultiPlay() {
        GameManager.SetGameMode(GameManager.MULTI_PLAYER);
        Debug.Log("Play Multiplayer");
    }

    public void ActionBtnSettings() {
        Debug.Log("Settings");
    }

    public void ActionBtnExit() {
        GameManager.ChangeScreen(GameScenes.ExitScreen);
    }
}
