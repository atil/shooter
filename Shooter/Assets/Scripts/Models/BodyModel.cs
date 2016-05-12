using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class BodyModel : ModelBase
	{
        private Vector3 _position;
        private Quaternion _rotation;
        private float _speed;
        private Bounds _bounds;

        public Vector3 Position
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

        public Bounds Bounds
        {
            get
            {
                return _bounds;
            }

            set
            {
                _bounds = value;
                NotifyPropertyChange("Bounds", _bounds);
            }
        }

        public IInputDispatcher InputDispatcher { get; set; }
    }
}