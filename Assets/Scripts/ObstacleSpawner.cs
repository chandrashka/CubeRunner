using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private int obstacleDistance;
    [SerializeField] private int obstacleStartZCoord;
    private int _obstacleCurrentZCoord;
    private readonly List<GameObject> _obstacles = new();
    private System.Random _random;

    private void Awake()
    {
        _random = new System.Random();
    }

    public void Start()
    {
        ResetSpawner();
    }

    public void ResetSpawner()
    {
        _obstacleCurrentZCoord = obstacleStartZCoord;
    }

    public void CreateObstacle()
    {
        var obstacleNum = _random.Next(0, obstaclePrefabs.Count);
        var obstaclePosition = new Vector3(0, 0, _obstacleCurrentZCoord);
        
        var obstacle = Instantiate(obstaclePrefabs[obstacleNum], obstaclePosition, Quaternion.identity);
        _obstacles.Add(obstacle);
        
        _obstacleCurrentZCoord += obstacleDistance;
    }
    
    private void DeleteObstacle(GameObject obstacle)
    {
        Destroy(obstacle);
    }

    public void DeleteAllObstacles()
    {
        for (var i = 0; i < _obstacles.Count; i++)
        {
            var obstacle = _obstacles[i];
            DeleteObstacle(obstacle);
        }
    }
}
