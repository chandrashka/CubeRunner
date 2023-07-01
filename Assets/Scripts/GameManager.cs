using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSetup gameSetup;

    private void Start()
    {
        gameSetup.SetUpGameScene();
    }
}
