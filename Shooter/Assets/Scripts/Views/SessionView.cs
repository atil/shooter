using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.ComponentModel;

namespace Shooter
{
    public delegate void OnReplayClicked();

    public class SessionView : ViewBase
    {
        public event OnReplayClicked OnReplayClicked;

        [SerializeField]
        private Text _scoreText;

        [SerializeField]
        private Text _livesText;

        [SerializeField]
        private Text _gameOverText;

        [SerializeField]
        private Button _replayButton;

        protected override void Awake()
        {
            _replayButton.onClick.AddListener(() =>
            {
                if (OnReplayClicked != null)
                {
                    OnReplayClicked();
                }
            });
        }

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

        public void OnPlay()
        {
            _gameOverText.gameObject.SetActive(false);
            _replayButton.gameObject.SetActive(false);
        }

        public void OnGameOver()
        {
            _gameOverText.gameObject.SetActive(true);
            _replayButton.gameObject.SetActive(true);
        }
    }
}