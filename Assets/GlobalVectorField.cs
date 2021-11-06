using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VectorField {
    float timeElapsed = 0;
    public float Scale = 1;
     public float PerlinNoise3D(float x, float y, float z){
        x /= Scale;
        y /= Scale;
        z /= Scale;
        float xy = Mathf.PerlinNoise(x, y);
        float xz = Mathf.PerlinNoise(x, z);
        float yz = Mathf.PerlinNoise(y, z);
        float yx = Mathf.PerlinNoise(y, x);
        float zx = Mathf.PerlinNoise(z, x);
        float zy = Mathf.PerlinNoise(z, y);
        return (xy + xz + yz + yx + zx + zy) / 6;
    }

    public Vector3 VectorField3D(Vector3 pos){
        pos.x += timeElapsed;
        pos.y += timeElapsed;
        pos.z += timeElapsed;

        float x =  PerlinNoise3D(pos.x, pos.y, pos.z) - 0.5f;
        float y = PerlinNoise3D(pos.x + 12.2f, pos.y + 42.2f, pos.z + 1.54f) - 0.5f;
        float z = PerlinNoise3D(pos.x + 4.12f, pos.y + 6.443f, pos.z + 43.2f) - 0.5f;
        return new Vector3(x, y, z);
    }
    public void Update(float dt) {
        timeElapsed += dt;
    }
}

public class GlobalVectorField : MonoBehaviour
{
    public VectorField vf;
    public float vscale = 1;

    private void Start() {
        vf = new VectorField();
    }
    void Update()
    {
        vf.Update(Time.deltaTime);
        vf.Scale = vscale;
    }
}
