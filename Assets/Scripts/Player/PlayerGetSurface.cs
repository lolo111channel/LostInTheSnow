using UnityEngine;

namespace LostInTheSnow
{
    public enum SURFACES
    {
        SNOW,
        PLANK
    }


    public class PlayerGetSurface : MonoBehaviour
    {
        public SURFACES CurrentSurface { get; private set; } = SURFACES.SNOW;


        private void FixedUpdate()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 100))
            {
                GameObject obj = hit.collider.gameObject;
                Surface objSurface = obj.GetComponent<Surface>();
                if (objSurface != null)
                {

                    CurrentSurface = objSurface.GetSurface();
             
                }
            
            }
        }

    }

}
