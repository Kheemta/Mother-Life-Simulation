using Mir.Core;
using UnityEngine;
namespace Mir
{
    public class DracoArts : Singleton<DracoArts>
    {
        public GameManager gameManager;
        public APIManager apiManager;
       // public BlockchainManager blockchainManager;

        public bool isDevelopment = true;


       
        private void OnEnable()
        {
           
            //DataCentre.Load(); // obselete method
            // load local datastorage
            // load other assets

        }
        private void OnDisable()
        {
            //save localstorage
            // unload other assets
        }
    }
}
