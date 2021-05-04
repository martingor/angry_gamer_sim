using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private Sprite[] background;
    [SerializeField] private GameState controller;
    public GameObject gameObjectsToHide;
    public void SetupGame(int imgNumber)
    {
        this.gameObject.SetActive(true);
        gameObjectsToHide.SetActive(false);
        //this.gameObject.GetComponent<Image>().sprite = background[imgNumber];
        this.transform.SetAsLastSibling();
        controller.playing = true;
    }

    public void CloseGame()
    {
        this.gameObject.SetActive(false);
        gameObjectsToHide.SetActive(true);
        controller.playing = false;
    }

}
