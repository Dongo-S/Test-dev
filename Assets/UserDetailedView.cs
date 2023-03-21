using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class UserDetailedView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameText;

    [SerializeField]
    Image photo;

    [SerializeField]
    TextMeshProUGUI emailText;

    [SerializeField]
    TextMeshProUGUI genderText;

    [SerializeField]
    TextMeshProUGUI ageText;

    [SerializeField]
    TextMeshProUGUI cityText;

    IDisposable _imageRequest;

    public void SetUserDetails(UserData user)
    {
        if (_imageRequest != null)
        {
            _imageRequest.Dispose();
            _imageRequest = null;
        }

        nameText.text = user.name.GetFullName();
        emailText.text = user.email;
        genderText.text = user.gender;
        cityText.text = user.location.city;
        ageText.text = user.dob.age.ToString();

        _imageRequest = ObservableWWW.GetAndGetBytes(user.picture.large)
            .Subscribe(
                x => OnSucces(x), // onSuccess
                ex => OnError(ex)); // onError
        gameObject.SetActive(true);
    }

    public void OnSucces(byte[] data)
    {
        var tex = new Texture2D(1, 1);
        tex.LoadImage(data);
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 128, 128), new Vector2());
        photo.sprite = sprite;

        _imageRequest = null;
    }

    public void OnDisable()
    {
        photo.sprite = null;
    }


    public void OnError(Exception error)
    {
        Debug.LogError(error);
        _imageRequest = null;
    }
}
