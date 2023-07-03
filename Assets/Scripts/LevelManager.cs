using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private ObstacleSpawner _obstacleSpawner;
    private CubeSpawner _cubeSpawner;
    private GameSetup _gameSetup;
    private const int StartTracksNum = 3;
    [SerializeField] private GameObject player;
    private PlayerLogic _playerLogic;

    private void Awake()
    {
        _obstacleSpawner = GetComponent<ObstacleSpawner>();
        _cubeSpawner = GetComponent<CubeSpawner>();
        _gameSetup = GetComponent<GameSetup>();
        _playerLogic = player.GetComponent<PlayerLogic>();
    }

    public void CreateScene()
    {
        CreateFullTrack();
        _gameSetup.MovePlayerToStart();
    }

    private void CreateFullTrack()
    {
        for (int i = 0; i < StartTracksNum; i++)
        {
            CreateTrackPart();
        }
    }

    private void CreateTrackPart()
    {
        _gameSetup.CreateTrack();
        _obstacleSpawner.CreateObstacle();
        _cubeSpawner.CreateCubeGroup();
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
        
        _cubeSpawner.DeleteAllCubes();
        _cubeSpawner.ResetSpawner();
        
        _gameSetup.ResetGameSetUp();
        _gameSetup.DeleteTrack();
        
        CreateScene();
    }
    

    public void EndLevel()
    {
        StopMovement();
    }
}
