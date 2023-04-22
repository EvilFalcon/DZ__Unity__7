using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private TakeItem _takeItem;

        private void Awake()
        {
            _playerMovement = gameObject.AddComponent<PlayerMovement>().GetComponent<PlayerMovement>();
            _takeItem = gameObject.AddComponent<TakeItem>().GetComponent<TakeItem>();
        }
    }
}