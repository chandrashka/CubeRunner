using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenuCanvas;
    [SerializeField] private GameObject endGameCanvas;


    public void SetStartMenu()
    {
        startMenuCanvas.SetActive(true);
        endGameCanvas.SetActive(false);
    }

    public void SetGameMenu()
    {
        startMenuCanvas.SetActive(false);
        endGameCanvas.SetActive(false);
    }

    public void SetEndMenu()
    {
        startMenuCanvas.SetActive(false);
        endGameCanvas.SetActive(true);
    }
}
