using Item.Iinterfase;
using UnityEngine;

namespace Item
{
    public class Coin:MonoBehaviour,IPickUp
    {

        public void Get()
        {
           Destroy(gameObject);
        }
    }
}