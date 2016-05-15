using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class SessionController : ControllerBase
    {
        [Inject]
        private BodyController _bodyController;

        private SessionModel _sessionModel;
        private SessionView _sessionView;

        public override void Init()
        {
            base.Init();
            _bodyController.OnPlayerDied += OnPlayerDied;
            _bodyController.OnBotDied += OnBotDied;

        }

        private void InitScene()
        {
            _sessionView.OnPlay();
            _sessionModel.Lives = 3;
            _sessionModel.Score = 0;

            Container.CreateElement<PlayerShip>();
            DestroyViews<BotShipView>();
            for (var i = 0; i < 20; i++)
            {
                Container.CreateElement<BotShip>();
            }
        }

        private void OnPlayerDied()
        {
            CoroutineStarter.DelayedExecution(1, () =>
            {
                _sessionModel.Lives--;
                if (_sessionModel.Lives == 0)
                {
                    _sessionView.OnGameOver();
                }
                else
                {
                    Container.CreateElement<PlayerShip>();
                }
            });
        }

        private void OnBotDied(ViewBase killerView)
        {
            if (killerView is PlayerShipView)
            {
                _sessionModel.Score += 10;
            }
        }

        public override void InitModelView(ModelBase m, ViewBase v)
        {
            base.InitModelView(m, v);
            Debug.Assert(_sessionModel == null, "There shouldn't be more than one sessions");
            _sessionModel = (SessionModel)m;
            _sessionModel.Lives = 3;
            _sessionModel.Score = 0;

            _sessionView = (SessionView)v;
            _sessionView.OnPlay();
            _sessionView.OnReplayClicked += OnReplay;

            InitScene();
        }

        private void OnReplay()
        {
            InitScene();
        }
    }
}