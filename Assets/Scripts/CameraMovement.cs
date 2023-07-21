using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector3 _deltaPosition;
    
    private void Start()
    {
        _deltaPosition = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        var playerPosition = player.transform.position;
        transform.position =  new Vector3(playerPosition.x + _deltaPosition.x, transform.position.y, 
            playerPosition.z + _deltaPosition.z);
    }
}
