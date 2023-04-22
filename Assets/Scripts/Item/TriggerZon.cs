using Player;
using UnityEngine;


namespace Item
{
    public class TriggerZon:MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (TryGetComponent(out PlayerController player))
            {
                Destroy(gameObject);      
            }
        }
    }
}