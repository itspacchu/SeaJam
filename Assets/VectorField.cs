using System.Collections;
using System.Collections.Generic;

public class VectorField {
    struct Vec3 {
        public float x, y, z;
        public Vec3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Vec3 operator +(Vec3 a, Vec3 b) {
            return new Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vec3 operator -(Vec3 a, Vec3 b) {
            return new Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vec3 operator *(Vec3 a, float b) {
            return new Vec3(a.x * b, a.y * b, a.z * b);
        }
        public static Vec3 operator /(Vec3 a, float b) {
            return new Vec3(a.x / b, a.y / b, a.z / b);
        }
    };

    List<float> FieldCoefficients;
    List<Vec3> FieldDirections;
    public VectorField() {
        this.FieldDirections = new List<Vec3>();
    }
    
};