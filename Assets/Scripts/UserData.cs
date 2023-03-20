using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UserName
{
    public string title;
    public string first;
    public string last;
}
public struct UserBirth
{
    public string date;
    public int age;

}

public struct UserLocation
{
    public string city;
}

public struct UserPicture
{
    public string large;
    public string thumbnail;
}

public class UserData
{
    public string gender;
    public UserName name;
    public UserLocation location;
    public string email;
    public UserBirth dob;
    public UserPicture picture;
}
