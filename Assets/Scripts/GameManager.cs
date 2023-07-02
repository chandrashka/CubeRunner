using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public LevelManager levelManager;
    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        uiManager.SetStartMenu();
    }

    public void StartGame()
    {
        uiManager.SetGameMenu();
        levelManager.CreateScene();
        levelManager.StartMovement();
    }

    public void RestartGame()
    {
        levelManager.RestartLevel();
        uiManager.SetGameMenu();
        levelManager.StartMovement();
    }

    public void EndGame()
    {
        levelManager.EndLevel();
        uiManager.SetEndMenu();
    }
}
