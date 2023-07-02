using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 _deltaPosition;
    
    private void Start()
    {
        _deltaPosition = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position + _deltaPosition;
    }
}
