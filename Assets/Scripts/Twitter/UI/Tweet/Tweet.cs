using System;
using UnityEngine;
using UnityEngine.UI;

namespace Twitter.UI
{
    public class Tweet : MonoBehaviour
    {
        [SerializeField]
        private Text _userNameText;
        [SerializeField]
        private Text _messageText;
        [SerializeField]
        private Button _retweetButton;
        [SerializeField]
        private Button _likesButton;
        [SerializeField]
        private Image _userIconImage;

        public Action OnRetweetButtonClickAction { get; private set; }
        public Action OnLikesButtonClickAction { get; private set; }

        public void SetUserName(string userNameText)
        {
            this._userNameText.text = userNameText;
        }

        public void SetMessage(string messageText)
        {
            _messageText.text = messageText;
        }

        public void SetRetweetButtonOnClick(Action onRetweet)
        {
            OnRetweetButtonClickAction = onRetweet;
        }

        public void SetLikesButtonOnClick(Action onLike)
        {
            OnLikesButtonClickAction = onLike;
        }

        public void SetUserIcon(Sprite userIcon)
        {
            _userIconImage.sprite = userIcon;
        }

        #region PRIVATE METHODS

        private void Awake()
        {
            OnRetweetButtonClickAction = () => { };
            OnLikesButtonClickAction = () => { };
        }

        private void Start()
        {
            _retweetButton.onClick.AddListener(OnRetweetClick);
            _likesButton.onClick.AddListener(OnLikesClick);
        }

        private void OnRetweetClick()
        {
            OnRetweetButtonClickAction();
        }

        private void OnLikesClick()
        {
            OnLikesButtonClickAction();
        }

        #endregion
    }
}
