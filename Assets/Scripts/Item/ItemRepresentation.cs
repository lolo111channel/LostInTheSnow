using CBStuff.StringManipulation;
using UnityEngine;
using UnityEngine.Localization.Settings;


namespace LostInTheSnow
{ 
    public class ItemRepresentation : MonoBehaviour, IInteractionable, IHint
    {
        [SerializeField] private Item _item = null;

        public void OnEnable()
        {
            if (_item != null)
            {
                _item.Prefab = gameObject;
            }
        }

        public bool Interaction(GameObject whoInteracted, float time = 0)
        {
            
            Inventory inventory = whoInteracted.GetComponent<Inventory>();

            if (inventory != null)
            {
                inventory.PickUpItem(_item);
                Destroy(gameObject);
            }

            return true;
        }

        public string GetHint()
        {
            if (_item == null) return "Error";

            string localizedItemName = LocalizationSettings.StringDatabase.GetLocalizedString("items", _item.ItemName);
            string localizedTake = LocalizationSettings.StringDatabase.GetLocalizedString("other", "O_TAKE");
            localizedTake = StringManipulation.ChangeFirstLetterOnLarge(localizedTake);

            return $"{localizedTake} {localizedItemName}";
        }
    }

}

