using Item.Iinterfase;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(TriggerZone))]
    public class Gatherer : MonoBehaviour
    {
        private TriggerZone _triggerZone;

        private void Awake()
        {
            _triggerZone = GetComponent<TriggerZone>();
            _triggerZone.PickedUp += OnPickedUp;
        }

        private void OnDisable()
        {
            _triggerZone.PickedUp -= OnPickedUp;
        }

        private void OnPickedUp(IPickable item)
        {
            item.Get();
        }
    }
}