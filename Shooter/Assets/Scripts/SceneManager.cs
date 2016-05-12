using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class SceneManager : MonoBehaviour
    {
        private void Awake()
        {
            var succ = Container.Init();

            if (!succ)
            {
                return;
            }

            Container.CreateElement<Session>();
            Container.CreateElement<PlayerShip>();
        }

    }

}
