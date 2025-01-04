using UnityEngine;


namespace LostInTheSnow
{
    public class ShowCursor : MonoBehaviour
    {
        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
