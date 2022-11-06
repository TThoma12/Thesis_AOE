using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPos;
    public Vector2 minPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // This will keep the camera in bounds for the player
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y);

            // This will allow smooth movement for the camera when it's following the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
