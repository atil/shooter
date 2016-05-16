using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shooter
{

	public class BodyController : ControllerBase
	{
	    [Inject]
        private SessionController _sessionController;

	    [Inject]
        private BotShipController _botShipController;

        public void OnVolumeEnter(BodyView collider, BodyView collidee)
        {
            if (collider is PlayerShipView)
            {
                _sessionController.OnPlayerDied((PlayerShipView)collider, collidee);
                DestroyView(collider);
            }

            if (collider is BotShipView)
            {
                // Kills actually respawn bot
                _botShipController.RespawnBotView((BotShipView)collider);

                _sessionController.OnBotDied((BotShipView)collider, collidee);
            }

            if (collider is BulletView)
            {
                DestroyView(collider);
            }

        }
    }

}