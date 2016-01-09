using UnityEngine;
using System.Collections;

public class CameraMechanics : MonoBehaviour {
    public float cameraAcceleration;
    public float maxSpeed;

    Transform cameraFollow;
    Rigidbody rigid;
    Vector3 offsetUnitVec;
    float currentMagnitude;

    void Start()
    {
        cameraFollow = transform.parent;
        transform.parent = null;

        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;

        offsetUnitVec = transform.position - cameraFollow.position;

        currentMagnitude = offsetUnitVec.magnitude;
        offsetUnitVec = offsetUnitVec.normalized;
    }

    void FixedUpdate()
    {
        updateLocation();
    }

    void updateLocation()
    {
        Vector3 goalLocation = (cameraFollow.position + offsetUnitVec * currentMagnitude);
        Vector3 goalVelocity = (transform.position - goalLocation).normalized * maxSpeed;
        rigid.velocity = Vector3.Lerp(rigid.velocity, goalVelocity, Time.fixedDeltaTime * cameraAcceleration);
    }

    
}
