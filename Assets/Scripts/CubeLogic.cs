using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    private GameManager _gameManager;
    private GameObject _player;
    
    [SerializeField] private bool isPlayersCube;
    private float _cubeYCoordinate = 0.5f;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (isPlayersCube)
        {
            var playerPosition = _gameManager.GetPlayerPosition();

            var newPosition = new Vector3(playerPosition.x, _cubeYCoordinate, playerPosition.z);

            transform.position = newPosition;
        }
    }

    public void MoveCubeToPlayer(Vector3 position)
    {
        _cubeYCoordinate = position.y;
        AddToPlayer();
    }

    private void AddToPlayer()
    {
        isPlayersCube = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isPlayersCube && other.gameObject.TryGetComponent<CubeLogic>(out var logic))
        {
            _gameManager.AddCubeToPlayer(logic);
        }
    }
}
