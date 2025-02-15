using UnityEngine;


namespace LostInTheSnow
{
    public class Surface : MonoBehaviour
    {
        [SerializeField] private SURFACES surface;

        public SURFACES GetSurface() => surface;
    }

}

