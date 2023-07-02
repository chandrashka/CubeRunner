using System;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private int playerSpeed;
    private GameManager _gameManager;
    private bool _isMoving;
    private const float DistanceToObstacle = 0.5f;

    [SerializeField] private float sideMovementSpeed;
    

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                Rigidbody rigidbody = GetComponent<Rigidbody>();
                var xCoord = touch.deltaPosition.x;
                if (xCoord < 0)
                {
                    rigidbody.AddRelativeForce(transform.right * -sideMovementSpeed, ForceMode.Impulse);
                }
                else if(xCoord > 0)
                {
                    rigidbody.AddRelativeForce(transform.right * sideMovementSpeed, ForceMode.Impulse);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        
        if(_isMoving) transform.Translate(0,0,playerSpeed * Time.deltaTime);

        var position = transform.position;
        var rayBeginning = new Vector3(position.x, position.y, position.z);
        if (Physics.Raycast(rayBeginning, Vector3.forward, 
                DistanceToObstacle, LayerMask.GetMask("Wall")))
        {
            StopMovement();
            _gameManager.EndGame();
        }
    }

    public void StartMovement()
    {
        _isMoving = true;
    }
    
    public void StopMovement()
    {
        _isMoving = false;
    }
}
