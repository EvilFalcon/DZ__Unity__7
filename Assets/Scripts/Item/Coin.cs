using Item.Iinterfase;
using UnityEngine;

namespace Item
{
    public class Coin : MonoBehaviour, IPickable
    {
        public void Get()
        {
            Destroy(gameObject);
        }
    }
}