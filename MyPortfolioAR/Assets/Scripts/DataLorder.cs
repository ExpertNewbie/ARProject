using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLorder
{
    public static List<DataClass> LordData(TextAsset csvText)
    {
        var reader = new StringReader(csvText.text);
        List<DataClass> dataList = new List<DataClass>();
        while(reader.Peek() > -1)
        {
            var line = reader.ReadLine();
            var data = new DataClass();
            data.SetData(line.Split(','));
            dataList.Add(data);
        }
        return dataList;
    }
}
