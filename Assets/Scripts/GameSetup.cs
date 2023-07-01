using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject trackGroundPrefab;

    private readonly GameObject[] _track = new GameObject[3];
    
    private int _zCoordForNextTrack;
    private const int TrackLength = 30;
    private const int PlayerPositionZ = 2;

    public void SetUpGameScene()
    {
        CreateTrack();
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        var position = new Vector3(0, 0, PlayerPositionZ);
        Instantiate(playerPrefab, position, Quaternion.identity);
    }

    private void CreateTrack()
    {
        for (var i = 0; i < 3; i++)
        {
            var position = new Vector3(0, 0, _zCoordForNextTrack);
            _track[i] = Instantiate(trackGroundPrefab, position, Quaternion.identity);
            _zCoordForNextTrack += TrackLength;
        }
    }
}

