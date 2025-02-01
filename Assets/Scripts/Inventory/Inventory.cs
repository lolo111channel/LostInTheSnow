using Unity.VisualScripting;
using UnityEngine;


namespace LostInTheSnow
{
    public class Inventory : MonoBehaviour
    {
        public Item CurrentItem { get; private set; } = null;
        [SerializeField] private GameObject _startItem = null;
        [SerializeField] private Transform _itemHolder;
        [SerializeField] private Transform _itemInTheWorldPos;

        public void PickUpItem(Item item)
        {
            if (CurrentItem != null)
                DropItem();

            CurrentItem = item;
            CurrentItem.Prefab = Instantiate(CurrentItem.Prefab, _itemHolder);
            CurrentItem.Prefab.transform.localPosition = Vector3.zero;
            CurrentItem.Prefab.transform.localRotation = Quaternion.identity;

            Rigidbody rigidbodyItem = CurrentItem.Prefab.GetComponent<Rigidbody>();
            if (rigidbodyItem != null)
            {
                Destroy(rigidbodyItem);
            }
        }

        public void DropItem()
        {
            if (CurrentItem == null) return;

            if (CurrentItem.Prefab != null)
            {
                CurrentItem.Prefab.AddComponent<Rigidbody>();
                CurrentItem.Prefab.GetComponent<BoxCollider>().enabled = true;
                CurrentItem.Prefab.transform.parent = _itemInTheWorldPos.parent;
            }

            CurrentItem = null;
        }

        private void Start()
        {
            if (_startItem != null)
            {
                ItemRepresentation itemRepresentation = _startItem.GetComponent<ItemRepresentation>();
                Item item = itemRepresentation.GetItem();
                item.Prefab = _startItem;
                PickUpItem(item);
            }
        }

    }

}
