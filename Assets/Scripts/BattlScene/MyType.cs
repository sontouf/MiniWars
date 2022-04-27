using System.Collections;
using System.Collections.Generic;
public class MyType
{
    public enum UnitType { Sward = 0, Archer = 1, Shield = 2};
    static public Dictionary<string, MyType.UnitType> UnitTypeFromString = new Dictionary<string, MyType.UnitType>()
    {{"Sward", UnitType.Sward }, {"Archer", UnitType.Archer } };
    static public Dictionary<MyType.UnitType, string> StringFromUnitType = new Dictionary<UnitType, string>()
    { {UnitType.Sward, "Sward" }, {UnitType.Archer, "Archer" }};
    static public Dictionary<string, int> UnitCostFromString= new Dictionary<string, int>() {{"Sward", 3}, {"Archer", 5}};
    static public int [] UnitCost = new int[]{ 3, 5, 7};
    static public float[] UnitCoolTime = new float[] { 5f, 6f, 7f};
}
