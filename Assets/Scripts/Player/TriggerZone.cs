using System;
using Item.Iinterfase;
using UnityEngine;

namespace Player
{
    public class TriggerZone : MonoBehaviour
    {
        public event Action<IPickable> PickedUp;

        public void OnTriggerEnter2D(Collider2D boxCollider2D)
        {
            if (boxCollider2D.TryGetComponent(out IPickable pickUp))
            {
                PickedUp?.Invoke(pickUp);
            }
        }
    }
}