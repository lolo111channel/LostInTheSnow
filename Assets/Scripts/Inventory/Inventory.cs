using Unity.VisualScripting;
using UnityEngine;


namespace LostInTheSnow
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Item _currentItem = null;
        [SerializeField] private Transform _itemHolder;
        [SerializeField] private Transform _itemInTheWorldPos;

        public void PickUpItem(Item item)
        {
            if (_currentItem != null)
                DropItem();

            _currentItem = item;
            _currentItem.Prefab = Instantiate(_currentItem.Prefab, _itemHolder);
            _currentItem.Prefab.transform.localPosition = Vector3.zero;
            _currentItem.Prefab.transform.localRotation = Quaternion.identity;

            Rigidbody rigidbodyItem = _currentItem.Prefab.GetComponent<Rigidbody>();
            if (rigidbodyItem != null)
            {
                Destroy(rigidbodyItem);
            }
        }

        public void DropItem()
        {
            if (_currentItem == null) return;

            if (_currentItem.Prefab != null)
            {
               _currentItem.Prefab.AddComponent<Rigidbody>();
               _currentItem.Prefab.transform.parent = _itemInTheWorldPos.parent;
            }

            _currentItem = null;
        }
    }

}
