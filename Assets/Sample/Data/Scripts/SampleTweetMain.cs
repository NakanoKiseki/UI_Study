using System;
using System.Collections.Generic;
using UnityEngine;
using Twitter.UI;

public class SampleTweetMain : MonoBehaviour
{
    [Serializable]
    public struct TweetData
    {
        public string UserName;
        public string Message;
        public Sprite UserIcon;
    }

    [SerializeField]
    private GameObject _tweetPrefab;

    public TweetData[] TweetsData;
    
    private List<Tweet> _tweetList = new List<Tweet>();

    void Start()
    {
        GenerateTweets();
    }

    #region PRIVATE METHODS

    private void GenerateTweets()
    {
        foreach (var t in TweetsData)
        {
            var tweetUI = Instantiate<GameObject>(_tweetPrefab, this.transform);
            var tweet = tweetUI.GetComponent<Tweet>();
            _tweetList.Add(tweet);

            tweet.SetUserName(t.UserName);
            tweet.SetMessage(t.Message);
            tweet.SetUserIcon(t.UserIcon);
            tweet.SetRetweetButtonOnClick(() => { Debug.Log("Retweeted!"); });
            tweet.SetLikesButtonOnClick(() => { Debug.Log("Liked!"); });

            var tweetPos = new Vector3(0f, 0f, 0f);
            tweetPos.y = _tweetList.Count * 1.6f;
            tweetUI.transform.position = tweetPos;
        }
    }

    #endregion
}
