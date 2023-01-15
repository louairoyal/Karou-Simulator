using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform CameraPos;

    private void Update()
    {
        transform.position = CameraPos.position;    
    }
}
