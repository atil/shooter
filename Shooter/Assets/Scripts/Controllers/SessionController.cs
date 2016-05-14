using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class SessionController : ControllerBase
	{
        private SessionModel _sessionModel;

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