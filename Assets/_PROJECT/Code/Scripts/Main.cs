using _PROJECT.Code.ProductCatalog;
using UnityEngine;

namespace _PROJECT.Code.Scripts
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            var loader = new ProductCatalogLoader(string.Empty);
            var productCatalog = loader.Build();
            
            
        }
    }
}