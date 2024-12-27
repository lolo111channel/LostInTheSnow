using UnityEngine;

namespace LostInTheSnow
{ 
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance = 100.0f;

        public bool Interaction(float time)
        {
            Collider collider = GetHitCollider();
            if (collider == null)
                return true;

            IInteractionable interactionable = collider.gameObject.GetComponent<IInteractionable>();
            if (interactionable == null) return true;

            return interactionable.Interaction(gameObject, time);
        }


        private Collider GetHitCollider()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, _interactionDistance))
            {
                return hit.collider;
            }

            return null;
        }
    }

}

