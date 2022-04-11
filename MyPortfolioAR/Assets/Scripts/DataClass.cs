using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataClass
{
    public int Number { get; set; }
    public string SerialName { get; set; }
    public string ARName { get; set; }
    public void SetData(string[] dataArr)
    {
        Number = int.Parse(dataArr[0]);
        SerialName = dataArr[1];
        ARName = dataArr[2];
    }
}
