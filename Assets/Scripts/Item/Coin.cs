using Item.Iinterfase;
using UnityEngine;

namespace Item
{
    public class Coin : MonoBehaviour, IPickingUp
    {
        public void Get()
        {
            Destroy(gameObject);
        }
    }
}