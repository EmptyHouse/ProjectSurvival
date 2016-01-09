using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class WalkMechanics : MonoBehaviour {

    public float maxSpeed;
    public float acceleration;
    public float rotationAcceleration;


    public bool movementOn;
    public bool rotationOn;

    Rigidbody rigid;
    float hInput;
    float vInput;

    void Start()
    {
        print("What the actual fuck");
        rigid = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        updatePosition();
    }

    protected virtual void Update()
    {
        updateRotation();
    }

    public void setHInput(float hInput)
    {
        this.hInput = hInput;
    }

    public void setVInput(float vInput)
    {
        this.vInput = vInput;
    }


    void updatePosition()
    {
        if (!movementOn)
        {
            rigid.velocity = Vector3.zero;
            return;
        }
        float scale = Mathf.Max(hInput, vInput);
        Vector3 goalVelocity = new Vector3(hInput, rigid.velocity.y, vInput).normalized;
        goalVelocity *= maxSpeed;
        rigid.velocity = Vector3.Lerp(rigid.velocity, goalVelocity, Time.fixedDeltaTime * acceleration);
    }

    void updateRotation()
    {
        if (!rotationOn || (Mathf.Abs(hInput) < .01f && Mathf.Abs(vInput) < .01f))
        {
            return;
        }

        float directionY = Mathf.Atan2(vInput, hInput) * Mathf.Rad2Deg;
        Quaternion goalRotation = Quaternion.Euler(0, directionY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, goalRotation, Time.deltaTime * rotationAcceleration);
    }
}
