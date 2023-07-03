using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    private void FixedUpdate()
    {
        var position = transform.position;
        var rayBeginning = new Vector3(position.x, position.y, position.z);
 
        if (Physics.Raycast(rayBeginning, Vector3.forward, out var hitInfo, 0.5f) && 
            hitInfo.collider.gameObject.TryGetComponent<CubeLogic>(out var logic))
        {
            Destroy(hitInfo.collider.gameObject);
            
        }
    }
}
