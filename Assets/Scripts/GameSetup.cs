using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playersCube;
    [SerializeField] private GameObject trackGroundPrefab;

    private int _zCoordForNextTrack;
    private const int TrackLength = 30;
    private const int PlayerStartPositionZ = 2;
    
    public void MovePlayerToStart()
    {
        var playerPosition = new Vector3(0, 1, PlayerStartPositionZ);
        player.transform.position = playerPosition;
        var cubePosition = new Vector3(0, 0, PlayerStartPositionZ);
        playersCube.transform.Translate(cubePosition);
    }

    public void ResetGameSetUp()
    {
        _zCoordForNextTrack = 0;
    }

    public List<GameObject> CreateTrack()
    {
        var track = new List<GameObject>();
        for (var i = 0; i < 3; i++)
        {
            var position = new Vector3(0, 0, _zCoordForNextTrack);
            track.Add(Instantiate(trackGroundPrefab, position, Quaternion.identity));
            _zCoordForNextTrack += TrackLength;
        }

        return track;
    }
}

