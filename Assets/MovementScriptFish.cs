using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptFish : MonoBehaviour
{
    public Rigidbody rb;
    public float Force = 100f;
    public float rotForce = 300f;
    public GlobalVectorField GlobalField;

    public float ambientVectorFieldAmplitude = 1f;

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
        rb.AddForce(ambientVectorFieldAmplitude*GlobalField.vf.VectorField3D(transform.position));
        GlobalField.vf.Update(Time.fixedDeltaTime);
        Debug.DrawRay(transform.position, ambientVectorFieldAmplitude*GlobalField.vf.VectorField3D(transform.position), Color.green);
        for(float i=-10f;i < 10f;i+=2.5f){
            for(float j=-10f;j < 10f;j+=2.5f){
                for(float k=-10f;k<10f;k+=2.5f){
                    Debug.DrawRay(transform.position + new Vector3(i,j,k), 3f*GlobalField.vf.VectorField3D(transform.position + new Vector3(i,j,k)), Color.green);
                } 
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward );
    }
}
