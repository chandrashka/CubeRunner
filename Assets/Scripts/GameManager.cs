using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSetup gameSetup;

    private void Awake()
    {
        gameSetup.SetUpGameScene();
    }

    public GameObject GetPlayer()
    {
        return gameSetup.GetPlayer();
    }
}
