using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumHelper
{ 
    public static List<T> GetEnumList<T>()
    {
        T[] array = (T[])System.Enum.GetValues(typeof(T));
        List<T> list = new List<T>(array);
        return list;
    }
}
