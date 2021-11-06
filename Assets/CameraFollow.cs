using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float smoothening;
    public Vector3 offset;
    public float rotationSpeed = 0.1f;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 finpos = player.position + offset;
        Vector3 rtpos = Vector3.Lerp(transform.position, finpos, smoothening * Time.deltaTime);
        transform.position = rtpos;

        // lerped look at
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation , rotationSpeed * Time.deltaTime);
    }
}