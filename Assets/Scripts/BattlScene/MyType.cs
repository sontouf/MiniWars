using System.Collections;
using System.Collections.Generic;
public class MyType
{
    // unitType은 int 로 캐스팅 될수 있다. 여기 순서 굉장히 중요하다.
    public enum UnitType { Sward = 0, Archer = 1, Shield = 2};

    // 키값 또는 value 값을 가져올수 있는 프로퍼티가 있으면 밑에 두 함수중 하나는 지워도 된다. 
    static public Dictionary<string, MyType.UnitType> UnitTypeFromString = new Dictionary<string, MyType.UnitType>()
    {{"Sward", UnitType.Sward }, {"Archer", UnitType.Archer } };
    static public Dictionary<MyType.UnitType, string> StringFromUnitType = new Dictionary<UnitType, string>()
    { {UnitType.Sward, "Sward" }, {UnitType.Archer, "Archer" }};


    static public Dictionary<string, int> UnitCostFromString= new Dictionary<string, int>() {{"Sward", 3}, {"Archer", 5}};
    static public int [] UnitCost = new int[]{ 3, 5, 7};
    static public float[] UnitCoolTime = new float[] { 5f, 6f, 7f};
}
