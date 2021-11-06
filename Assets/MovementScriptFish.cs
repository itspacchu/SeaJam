using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptFish : MonoBehaviour
{
    public Rigidbody rb;
    public float Force = 100f;
    public float rotForce = 300f;

    public Camera camera;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetAxis("Jump") != 0)
            rb.AddForce(transform.forward * Force * Time.fixedDeltaTime);
        rb.AddTorque((this.transform.up * Input.GetAxis("Horizontal") + this.transform.right * Input.GetAxis("Vertical")) * rotForce * Time.fixedDeltaTime);
        //reset Z rotation to zero always
        Quaternion rtRot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        this.transform.rotation =  Quaternion.Slerp(this.transform.rotation, rtRot, 2f * Time.deltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward );
    }
}
