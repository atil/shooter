using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class BodyView : ViewBase
	{
        [SerializeField]
        private GameObject _sprite;

        public override void BindTo(ModelBase model)
        {
            base.BindTo(model);

            ((BodyModel)model).Position = transform.position;
        }

        protected override void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.ModelPropertyChanged(sender, e);
            if (e.PropertyName == "Position")
            {
                transform.position = (Vector2)e.Value;
            }

            if (e.PropertyName == "Rotation")
            {
                transform.rotation = (Quaternion) e.Value;
            }
        }
    }
}