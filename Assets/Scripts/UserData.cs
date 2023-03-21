using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct UserName
{
    public string title;
    public string first;
    public string last;

    public string GetFullName()

    {
        return string.Format("{0} {1} {2}", title, first, last);
    }
}


[Serializable]
public struct UserBirth
{
    public string date;
    public int age;

}

[Serializable]
public struct UserLocation
{
    public string city;
}

[Serializable]
public struct UserPicture
{
    public string large;
    public string thumbnail;
}

[Serializable]
public struct UserData
{
    public string gender;
    public UserName name;
    public UserLocation location;
    public string email;
    public UserBirth dob;
    public UserPicture picture;

}

[Serializable]
public struct UsersResults
{
    public List<UserData> results;
}
