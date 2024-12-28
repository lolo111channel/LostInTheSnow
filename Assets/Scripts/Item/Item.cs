using UnityEngine;

namespace LostInTheSnow
{
    [CreateAssetMenu(fileName = "item", menuName = "Item/New Item", order = 1)]
    public class Item : ScriptableObject
    {
        public int Id = 0;
        public string ItemName = "item";
        [HideInInspector] public GameObject Prefab = null;
    }
}
