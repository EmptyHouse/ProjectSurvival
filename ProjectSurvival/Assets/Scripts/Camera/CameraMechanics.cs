using UnityEngine;
using System.Collections;

public class CameraMechanics : MonoBehaviour {
    public float cameraAcceleration = 15;
    public float maxSpeed = 10;
    public float zoomAcceleration = 10;
    public float maxZoomFactor;
    public float minZoomFactor;

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

    void udpateZoom(float zoomFactor)
    {

    }

    void updateLocation()
    {
        Vector3 goalLocation = (cameraFollow.position + (offsetUnitVec * currentMagnitude));
        Vector3 goalVelocity = (-transform.position + goalLocation) * maxSpeed;
        rigid.velocity = Vector3.Lerp(rigid.velocity, goalVelocity, Time.fixedDeltaTime * cameraAcceleration);
    }

    
}
