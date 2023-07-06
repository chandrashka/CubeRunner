using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject trackGroundPrefab;

    private readonly List<GameObject> _tracks = new ();
    private int _zCoordForNextTrack;
    private const int TrackLength = 30;
    private readonly Vector3 _playerStartPosition = new (0,1,2);
    
    public void MovePlayerToStart()
    {
        player.transform.position = _playerStartPosition;
    }

    public void ResetGameSetUp()
    {
        _zCoordForNextTrack = 0;
    }

    public void CreateTrack()
    {
        var position = new Vector3(0, 0, _zCoordForNextTrack);
        var track = Instantiate(trackGroundPrefab, position, Quaternion.identity);
        _tracks.Add(track);
        _zCoordForNextTrack += TrackLength;
        
    }

    public void DeleteTrack()
    {
        for (var i = 0; i < _tracks.Count; i++)
        {
            Destroy(_tracks[i]);
        }
    }
}

