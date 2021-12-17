using UnityEngine;

namespace Input
{
    public class GrabController : MonoBehaviour
    {
        public static GrabController Instance { get; private set; }
        
        
        public bool isGrabbing;
        public Grabbable grabbedObject;
        
        public Transform grabPoint;
        public float grabMaxDistance = 5f;

        private void Awake()
        {
            Instance = this;
        }

        public void Throw()
        {
            grabbedObject.Throw(this);
        }

        public void Grab(Grabbable grabbable)
        {
            grabbable.Grab(this);
        }
    }
}
