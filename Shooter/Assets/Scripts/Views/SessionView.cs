using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.ComponentModel;

namespace Shooter
{
	public class SessionView : ViewBase
	{
        [SerializeField]
        private Text _scoreText;

        [SerializeField]
        private Text _livesText;

        public override void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.ModelPropertyChanged(sender, e);
            if (e.PropertyName == "Lives")
            {
                _livesText.text = "Lives: " + (int)e.Value;
            }
            else if (e.PropertyName == "Score")
            {
                _scoreText.text = "Score: " + (int)e.Value;
            }

        }
    }
}