using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimits : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    public float leftLimit;
    [SerializeField]
    public float rightLimit;
    [SerializeField]
    public float topLimit;
    [SerializeField]
    public float bottomLimit;


    // Update is called once per frame
    private void FixedUpdate()
    {
        //Vector3 startPos = transform.position;

        Vector3 endPos = player.transform.position;

        endPos.x += offset.x;
        endPos.y += offset.y;
        endPos.z = -100;

        Vector3 movePosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
           
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
