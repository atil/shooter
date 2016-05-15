using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class SessionController : ControllerBase
    {
        [Inject]
        private BodyController _bodyController;
        private SessionModel _sessionModel;

        public override void Init()
        {
            base.Init();
            _bodyController.OnPlayerDied += OnPlayerDied;
            _bodyController.OnBotDied += OnBotDied;

            Container.CreateElement<PlayerShip>();
            for (var i = 0; i < 20; i++)
            {
                Container.CreateElement<BotShip>();
            }

        }

        private void OnPlayerDied()
        {
            CoroutineStarter.DelayedExecution(1, () =>
            {
                Debug.Log("test");
            });
        }

        private void OnBotDied()
        {

        }

        public override void InitModelView(ModelBase m, ViewBase v)
        {
            base.InitModelView(m, v);
            Debug.Assert(_sessionModel == null, "There shouldn't be more than one sessions");
            _sessionModel = (SessionModel)m;
            _sessionModel.Lives = 3;
            _sessionModel.Score = 0;
        }


    }
}