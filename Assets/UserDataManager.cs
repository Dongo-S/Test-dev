using PolyAndCode.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

using Newtonsoft.Json;

public class UserDataManager : MonoBehaviour, IRecyclableScrollRectDataSource
{

    [SerializeField]
    RecyclableScrollRect _recyclableScrollRect;

    [SerializeField]
    private int _dataLength;

    [SerializeField]
    UsersResults userData;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Init()
    {
        ObservableWWW.Get("https://randomuser.me/api/?results=50")
    .Subscribe(
        x => OnSucces(x), // onSuccess
        ex => OnError(ex)); // onError
    }

    public void OnSucces(string data)
    {
        userData = JsonConvert.DeserializeObject<UsersResults>(data);

        Debug.Log(data);
        _recyclableScrollRect.Initialize(this);
    }


    public void OnError(Exception error)
    {
        Debug.LogError(error);
    }

    public int GetItemCount()
    {
        return userData.results.Count;

    }

    public void SetCell(ICell cell, int index)
    {
        var item = cell as UserDetails;
        item.ConfigureCell(userData.results[index]);
    }
}
