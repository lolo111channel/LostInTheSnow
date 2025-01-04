using System;
using System.Collections.Generic;
using UnityEngine;

namespace LostInTheSnow
{
    public class ReferencesForDialogue : MonoBehaviour
    {

        [SerializeField] private ReferenceDict _refs;
        private Dictionary<string, GameObject> _references = new();


        public GameObject GetReference(string referenceName)
        {
            return _references[referenceName];
        }

        private void Start()
        {
            _references = _refs.ToDictionary();
        }


        [Serializable]
        private class ReferenceDict
        {
            [SerializeField] private ReferencesDictItem[] _items;

            public Dictionary<string, GameObject> ToDictionary()
            {
                Dictionary<string, GameObject> newDict = new();
                foreach (var item in _items) 
                {
                    newDict.Add(item.name, item.reference);
                }

                return newDict;
            }
        }

        [Serializable]
        private class ReferencesDictItem
        {
            public string name;
            public GameObject reference;
        }
    }

}


