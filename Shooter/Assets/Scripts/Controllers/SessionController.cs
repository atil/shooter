using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class SessionController : ControllerBase
    {

        private SessionModel _sessionModel;
        private SessionView _sessionView;

        public override void Init()
        {
            base.Init();
            Session.IsPaused = false;
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

        public void OnPlayerDied(PlayerShipView playerView, BodyView killerView)
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
                    // Respawn
                    Container.CreateElement<PlayerShip>();
                }
            });
        }

        public void OnBotDied(BotShipView botView, BodyView killerView)
        {
            if (killerView is BulletView)
            {
                // Player killed a bot, increment score
                _sessionModel.Score += ((BotShipModel)ViewToModel[botView]).Score;
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

        protected override void OnInput(ModelBase modelBase, InputType inputType, float inputStrength)
        {
            base.OnInput(modelBase, inputType, inputStrength);
            if (inputType == InputType.Pause)
            {
                Session.IsPaused = !Session.IsPaused;
                _sessionView.SetPaused(Session.IsPaused);
            }

        }
    }
}