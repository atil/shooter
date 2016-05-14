using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField]
        private WorldObjects _worldObjects;

        private void Awake()
        {
            var initSucc = Container.Init(new object[] { _worldObjects });

            if (!initSucc)
            {
                return;
            }

            Container.CreateElement<Session>();
            Container.CreateElement<PlayerShip>();

            for (var i = 0; i < 20; i++)
            {
                Container.CreateElement<BotShip>();
            }
        }

        private void Update()
        {
        }
    }

}
