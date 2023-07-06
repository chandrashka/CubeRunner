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

    public void AddCubeToPlayer(CubeLogic logic)
    {
        levelManager.AddCubeToPlayer(logic);
    }

    public Vector3 GetPlayerPosition()
    {
        return levelManager.GetPlayerPosition();
    }
}
