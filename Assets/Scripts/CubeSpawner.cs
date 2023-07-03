using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    [SerializeField] private int maxCubesToSpawn;
    [SerializeField] private int minCubesToSpawn;
    [SerializeField] private int maxXCoord;
    [SerializeField] private int minXCoord;

    [SerializeField] private int distanceBetweenCubeGroups;
    [SerializeField] private int minDistanceBetweenCubesInGroup;
    [SerializeField] private int maxDistanceBetweenCubesInGroup;
    [SerializeField] private int cubeStartZCoord;
    private int _cubeCurrentZCoord;
    private int _groupNum;

    private readonly List<GameObject> _cubes = new ();
    private const float CubeYCoord = 0.5f;

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
        _cubeCurrentZCoord = cubeStartZCoord;
    }

    public void CreateCubeGroup()
    {
        _cubeCurrentZCoord += distanceBetweenCubeGroups * _groupNum;
        var cubesToSpawn = _random.Next(minCubesToSpawn, maxCubesToSpawn);
        
        for (var i = 0; i < cubesToSpawn; i++)
        {
            var cubeXCoord = _random.Next(minXCoord, maxXCoord);
            var cubePosition = new Vector3(cubeXCoord,CubeYCoord, _cubeCurrentZCoord);
            var cube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
            _cubes.Add(cube);
        
            _cubeCurrentZCoord += _random.Next(minDistanceBetweenCubesInGroup, maxDistanceBetweenCubesInGroup);
        }

        _groupNum++;
    }

    public void DeleteAllCubes()
    {
        for (var i = 0; i < _cubes.Count; i++)
        {
            var obstacle = _cubes[i];
            Destroy(obstacle);
        }
    }
}
