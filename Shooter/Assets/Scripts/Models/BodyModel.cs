using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class BodyModel : ModelBase
	{
        private Vector2 _position;
        private Quaternion _rotation;
        private float _speed;

        public Vector2 Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
                NotifyPropertyChange("Position", _position);
            }
        }

        public Quaternion Rotation
        {
            get
            {
                return _rotation;
            }

            set
            {
                _rotation = value;
                NotifyPropertyChange("Rotation", _rotation);

            }
        }

        public float Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
                NotifyPropertyChange("Speed", _speed);

            }
        }

        public IInputDispatcher InputDispatcher { get; set; }
    }
}