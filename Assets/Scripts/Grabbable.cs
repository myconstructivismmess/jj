using UnityEngine;

using Input;

public class Grabbable : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(GrabController grabController)
    {
        grabController.isGrabbing = true;
        
        _rigidbody.detectCollisions = false;
        _rigidbody.useGravity = false;
        
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        
        _transform.SetParent(grabController.grabPoint);
        _transform.localPosition = Vector3.zero;
        grabController.grabbedObject = this;
    }

    public void Throw(GrabController grabController)
    {
        grabController.isGrabbing = false;
        
        _transform.SetParent(null);
        grabController.grabbedObject = null;
        
        _rigidbody.detectCollisions = true;
        _rigidbody.useGravity = true;
    }
}
