using PolyAndCode.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserDetails : MonoBehaviour, ICell
{
    [SerializeField]
    TextMeshProUGUI nameText;

    [SerializeField]
    Image photo;

    [SerializeField]
    Button showDetailsButton;

    [SerializeField]
    Button likeButton;

    [SerializeField]
    Image likeImage;

    [SerializeField]
    UserData userData;

    IDisposable _imageRequest;

    [SerializeField]
    UserDetailedView userDetailedView;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonListener);
    }

    private void ButtonListener()
    {
        userDetailedView.SetUserDetails(userData);
    }

    public void ConfigureCell(UserData userInfo)
    {
        nameText.text = userInfo.name.GetFullName();
        userData = userInfo;
        SetUserImage(userData);
    }

    public void SetUserImage(UserData user)
    {

        if (_imageRequest != null)
        {
            _imageRequest.Dispose();
            _imageRequest = null;
        }

        _imageRequest = ObservableWWW.GetAndGetBytes(user.picture.thumbnail)
    .Subscribe(
        x => OnSucces(x), // onSuccess
        ex => OnError(ex)); // onError
    }

    public void OnSucces(byte[] data)
    {
        var tex = new Texture2D(1, 1); 
        tex.LoadImage(data);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 48, 48), new Vector2());
        photo.sprite = sprite;

        _imageRequest = null;
    }


    public void OnError(Exception error)
    {
        Debug.LogError(error);
        _imageRequest = null;

    }

}

