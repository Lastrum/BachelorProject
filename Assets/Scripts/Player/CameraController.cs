using UnityEngine;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private int transitionSpeed;
        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - target.position;
        }

        private void LateUpdate()
        {
            Vector3 newPosition = new Vector3(target.position.x, offset.y + target.position.y, offset.z + target.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, transitionSpeed * Time.fixedDeltaTime);
        }
    }
}
