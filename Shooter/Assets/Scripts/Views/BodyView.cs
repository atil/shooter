using UnityEngine;
using System.Collections;

namespace Shooter
{
    public delegate void OnTriggerEnterHandler(ViewBase view1, ViewBase view2);

	public class BodyView : ViewBase
	{
        public event OnTriggerEnterHandler OnVolumeEnter;

        [SerializeField]
        protected GameObject Sprite;

        public override void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
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

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (OnVolumeEnter != null)
            {
                OnVolumeEnter(this, coll.GetComponent<ViewBase>());
            }
        }

    }
}