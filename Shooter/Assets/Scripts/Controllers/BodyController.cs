using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shooter
{
    public delegate void OnPlayerDiedHandler();
    public delegate void OnBotDiedHandler(ViewBase killerView);

	public class BodyController : ControllerBase
	{
        public event OnPlayerDiedHandler OnPlayerDied;
        public event OnBotDiedHandler OnBotDied;

        public void OnVolumeEnter(ViewBase collider, ViewBase collidee)
        {
            var collidedModel = ViewToModel[collider] as BodyModel;
            DestroyView(collider);

            // TODO: Below looks bad
            if (collider is PlayerShipView)
            {
                if (OnPlayerDied != null)
                {
                    OnPlayerDied();
                }
            }

            if (collider is BotShipView)
            {
                if (OnBotDied != null)
                {
                    OnBotDied(collidee);
                }
            }

        }
    }

}