using TMPro;
using UnityEngine;

namespace LostInTheSnow
{
    public class HintView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _hint;
        private static TMP_Text _hintTMP;

        public static void SetHint(string newHint)
        {
            if (_hintTMP != null)
            {
                _hintTMP.text = newHint;
            }
        }

        private void OnEnable()
        {
            _hintTMP = _hint;
        }
    }

}

