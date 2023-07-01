using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private GameManager gameManager;

    private Vector3 _deltaPosition;

    private void Start()
    {
        _player = gameManager.GetPlayer();
        _deltaPosition = transform.position - _player.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = _player.transform.position + _deltaPosition;
    }
}
