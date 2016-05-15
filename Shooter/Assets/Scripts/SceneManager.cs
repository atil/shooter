using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField]
        private WorldObjects _worldObjects;

        private void Start()
        {
            var initSucc = Container.Init(new object[] { _worldObjects });

            if (!initSucc)
            {
                return;
            }

            Container.CreateElement<Session>();
           
        }

    }

}
