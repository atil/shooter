using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class BulletView : BodyView
	{
        protected override void Awake()
        {
            base.Awake();
            InputDispatcher = gameObject.AddComponent<BulletInputDispatcher>();
        }
    }
}