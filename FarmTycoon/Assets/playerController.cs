using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour, Controls.IPlayerActions{


    Vector3 direction;
    public float speed = 1;

    Rigidbody rb;

    private void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    public void Update() {

        rb.velocity = direction * speed;
    }

    public void OnMove(InputAction.CallbackContext context) {
        Vector2 readVector = context.ReadValue<Vector2>();
        Vector3 toConvert = new Vector3(readVector.x, 0, readVector.y);
        direction = isoVectorConvert(toConvert);
    }

    private Vector3 isoVectorConvert(Vector3 vector) {
        Quaternion rotation = Quaternion.Euler(0, 45.0f, 0);
        Matrix4x4 isoMatrix = Matrix4x4.Rotate(rotation);
        Vector3 result = isoMatrix.MultiplyPoint3x4(vector);
        return result;
    }
}
