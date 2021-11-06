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
        // find angle between player and camera
        Vector3 dir = (player.position - transform.position).normalized;
        float yAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        Quaternion rtRot = Quaternion.Euler(0, 0, yAngle);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rtRot, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}