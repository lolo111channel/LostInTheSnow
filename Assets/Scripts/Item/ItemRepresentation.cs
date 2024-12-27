using UnityEngine;


namespace LostInTheSnow
{ 
    public class ItemRepresentation : MonoBehaviour, IInteractionable
    {
        [SerializeField] private Item _item;

        public bool Interaction(GameObject whoInteracted, float time = 0)
        {
            Debug.Log(_item.ItemName);
            return true;
        }
    }

}

