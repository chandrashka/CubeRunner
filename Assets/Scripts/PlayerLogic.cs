using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private int playerSpeed;
    private void FixedUpdate()
    {
        transform.Translate(0,0,playerSpeed * Time.deltaTime);
    }
}
