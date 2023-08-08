using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AnimalsData 
{
    public List<Animal> Animals = new List<Animal>();
}
[Serializable]
public class Animal
{
    public Status status = new Status();
    public string _id = "";
    public string user = "";
    public string text = "";
    public string type = "";
    public bool deleted;
    public DateTime createdAt = new DateTime();
    public DateTime updatedAt = new DateTime();
    public int __v;
}

[Serializable]
public class Status
{
    public object verified = null;
    public int sentCount;
}



