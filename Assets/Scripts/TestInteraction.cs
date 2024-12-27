using UnityEngine;

namespace LostInTheSnow
{
    public class TestInteraction : MonoBehaviour, IInteractionable
    {
        public bool Interaction(GameObject whoInteracted, float time = 0)
        {

            if (time >= 2.0f)
            {
                Debug.Log("Interacted");
                return true;
            }

            return false;
        }
    }

}

