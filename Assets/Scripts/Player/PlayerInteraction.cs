using UnityEngine;

namespace LostInTheSnow
{ 
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance = 100.0f;
        [SerializeField] private Camera _camera;

        public bool Interaction(float time)
        {
            
            Collider collider = GetHitCollider();
            if (collider == null)
                return true;

            IInteractionable interactionable = collider.gameObject.GetComponent<IInteractionable>();
            if (interactionable == null) return true;

            return interactionable.Interaction(gameObject, time);
        }

        private void FixedUpdate()
        {
            Collider collider = GetHitCollider();
            if (collider != null)
            {
                IHint hint = collider.gameObject.GetComponent<IHint>();
                if (hint != null)
                    HintView.SetHint(hint.GetHint());
                else
                    HintView.SetHint("");
            }
        }


        private Collider GetHitCollider()
        {
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, _interactionDistance))
            {
                return hit.collider;
            }

            return null;
        }
    }

}

