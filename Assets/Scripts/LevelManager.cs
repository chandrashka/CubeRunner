using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private ObstacleSpawner _obstacleSpawner;
    private GameSetup _gameSetup;
    [SerializeField] private GameObject player;
    private PlayerLogic _playerLogic;
    
    private List<GameObject> _track = new();

    private void Awake()
    {
        _obstacleSpawner = GetComponent<ObstacleSpawner>();
        _gameSetup = GetComponent<GameSetup>();
        _playerLogic = player.GetComponent<PlayerLogic>();
    }

    public void CreateScene()
    {
        _track = _gameSetup.CreateTrack();
        _gameSetup.MovePlayerToStart();

        for (var i = 0; i < 4; i++)
        {
            _obstacleSpawner.CreateObstacle();
        }
    }

    public void StartMovement()
    {
        _playerLogic.StartMovement();
    }

    private void StopMovement()
    {
        _playerLogic.StopMovement();
    }

    public void RestartLevel()
    {
        _obstacleSpawner.DeleteAllObstacles();
        _obstacleSpawner.ResetSpawner();
        _gameSetup.ResetGameSetUp();
        DeleteTrack();
        CreateScene();
    }

    private void DeleteTrack()
    {
        for (var i = 0; i < _track.Count; i++)
        {
            Destroy(_track[i]);
        }
    }

    public void EndLevel()
    {
        StopMovement();
    }
}
