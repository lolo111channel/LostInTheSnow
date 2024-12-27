using UnityEngine;

namespace LostInTheSnow
{
    public interface IInteractionable
    {
        public bool Interaction(GameObject whoInteracted, float time = 0.0f);
    }
}
