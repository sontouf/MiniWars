# MiniWars

- ~~4/27~~ 개발 시작한지 9개월만에 처음 시작하는 개발 정리. 현재까지 개발된 부분의 클래스관계도 정리와 리펙토링하며 조금씩 업데이트하고자 한다. 3주정도 해볼 예정.



## C# script

> - **PlayerData 클래스**
>
>   > player의 정보. 저장과 불러오기 구현 필요.
>   >
>   > | 접근한정자 |      | 변수                                                         |
>   > | ---------- | ---- | ------------------------------------------------------------ |
>   > | **public** |      | **static int** clearStageNumber = 0                          |
>   > |            |      | **static List<int>** unitObjectList = **new List<int>()** {10000, 10100, 10200, 10500} |
>   > |            |      | **static int** unlockUnitNumber = 4                          |
>
> - **SceneManagerScript**
>
>   > scene 관리에 관한 함수가 구현되어있다.
>   >
>   > | 접근한정자 |      | 변수                                                         |
>   > | ---------- | ---- | ------------------------------------------------------------ |
>   > | **public** |      | **static int** clearStageNumber = 0                          |
>   > |            |      | **static List<int>** unitObjectList = **new List<int>()** {10000, 10100, 10200, 10500} |
>   > |            |      | **static int** unlockUnitNumber = 4                          |
>
> - **MyType**
>
>   > 게임구성에 필요한 데이터. 레벨링과 게임구성정보가 들어있다. - 나중에 file I/O로 구현하기.
>   >
>   > | 접근한정자 |      | 변수                                                         |
>   > | ---------- | ---- | ------------------------------------------------------------ |
>   > | **public** |      | **enum UnitType** {Sward, Archer, ArmouredSward, ArtilleryMan, Cavalry, Patrol, RoyalGuard, Shield, SpearMan} |
>   > |            |      | **static Dictionary<string, MyType,UnitType>** UnitTypeFromString = **new Dictionary<string, MyType.UnitType>()** |
>   > |            |      | **static Dictionary<string, int>** UnitCostFromString = **new Dictionary<string, int>()** |
>   > |            |      | **static int[]** UnitCost = **new int[]**                    |
>   > |            |      | **static float[]** UnitCoolTime = **new float[]**            |





## 첫 화면 (StartScene)

- **StartButton**
- **ExitButton**

## 스테이지 선택 (StageSelectScene) && 유닛 선택

- **StageSelectitem**

  > 클리어하고자 하는 스테이지를 선택할 수 있다. Menu, Setting, Recruit 등의 추가 옵션이 있다.

- **StageInfo**

  > 스테이지를 선택하면 해당 스테이지에 대한 팁과 정보를 얻을 수 있다.

- **StageItem**

  > 유닛의 대한 정보를 볼 수 있고 출전시키고자 하는 유닛을 선택할 수 있다. 

### c# script

> - **UnitBox 클래스**
>
>   > StageSelectScene 첫 화면 관리. - 여기서 이게 필요한건가?
>   >
>   > player의 유닛을 관리하기위해 유닛sprite 정보를 받아와서 저장해놓는다. page 관리.
>   >
>   > | 접근한정자  | 메소드                                       | 변수                                               |
>   > | ----------- | -------------------------------------------- | -------------------------------------------------- |
>   > | **public**  | **void** Left()                              |                                                    |
>   > |             | **void** Right()                             |                                                    |
>   > |             |                                              | **Sprite** empty                                   |
>   > |             |                                              | **Sprite** lockSprite                              |
>   > |             |                                              | **List<GameObject>** pageUnits                     |
>   > |             |                                              | **List<GameObject>** selectedUnits                 |
>   > |             |                                              | **Dictionary<GameObject, int>** pageUnitIds        |
>   > |             |                                              | **static int[]** selectedUnitIds  = **new int[8]** |
>   > |             |                                              | **static int** selectedUnitNumber                  |
>   > | **private** | **void** SettingUnitBox()                    |                                                    |
>   > |             | **Sprite** UnitBoxController(**int** unitId) |                                                    |
>   > |             |                                              | **GameObject** openPage                            |
>   > |             |                                              | **GameObject** stageItem                           |
>   > |             |                                              | **GameObject[]** pages = **new GameObject[3]**     |
>   >
>   > | Function Name     | parameter | return | 설명                                            |
>   > | ----------------- | :-------: | :----: | ----------------------------------------------- |
>   > | Left              |   void    |  void  | 페이지를 왼쪽으로 넘긴다. 맨 왼쪽이면 유지.     |
>   > | Right             |   void    |  void  | 페이지를 오른쪽으로 넘긴다. 맨 오른쪽이면 유지. |
>   > | SettingUnitBox    |   void    |  void  | unitBox의 sprite를 채워넣어준다.                |
>   > | UnitBoxController |    int    | Sprite | unitId를 통해 해당 sprite를 반환한다.           |
>
> ---
>
> - **ClickUnitButton 클래스**
>
>   > 출전시키고자하는 유닛을 선택하게 해준다.
>   >
>   > 각각의 UnitButton이 script 기능을 가진다. -> UnitButton controller를 만들어서 한 클래스에서 작동시키게 할지는 고민해보기. 
>   > UnitButton -- 30개, SelectedUnitButton - 8개
>   >
>   > | 접근한정자  | 메소드                        | 변수                        |
>   > | ----------- | ----------------------------- | --------------------------- |
>   > | **public**  | **void** PlayerUnitButton()   |                             |
>   > |             | **void** SelectedUnitButton() |                             |
>   > |             |                               | **UnitBox** unitBox         |
>   > | **private** | **void** CheckEmpty()         |                             |
>   > |             | **void** CheckObjec()         |                             |
>   > |             |                               | **int** firstEmptyUnitIndex |
>   > |             |                               | **int** nowUnitIndex        |
>   >
>   > | Function Name      | parameter | return | 설명                                                         |
>   > | ------------------ | :-------: | :----: | ------------------------------------------------------------ |
>   > | PlayerUnitButton   |   void    |  void  | 빈공간이 있는지 확인하고 빈공간이 있다면 해당 공간의 유닛 sprite와 유닛 Id를 변경해준다. |
>   > | SelectedUnitButton |   void    |  void  | 출전을 취소하고자 하는 유닛을 체크하고 유닛이 있다면 해당 공간의 유닛 Sprite와 유닛 Id를 초기화시킨다. |
>   > | CheckEmpty         |   void    |  int   | empty에 해당되는 첫 위치를 찾아서 firstEmptyUnitIndex에 저장한다. |
>   > | CheckObject        |   void    |  int   | 선택한 버튼이 유닛이 저장되어있는 버튼이면 현재 위치를 반환한다. |
>
> ---
>
> - **UnitSpriteManager 클래스**
>
>   > 게임내에 필요한 모든 sprite를 받아와서 정리한다.
>   >
>   > | 접근한정자  |      | 변수                                                         |
>   > | ----------- | ---- | ------------------------------------------------------------ |
>   > | **public**  |      | **static Dictionary<int, List<Sprite>>** unitOnList = **new Dictionary<int, List<Sprite>>()** |
>   > |             |      | **staitc Dictionary<int, List<Sprite>>** unitOffList = **new Dictionary<int, List<Sprite>>()** |
>   > |             |      | **static Dictionary<int, List<Sprite>>** redUnitList = **new DIctionary<int, List<Sprite>>()** |
>   > | **private** |      | **Sprite[]** playerAndEnemyUnitSpritesOn                     |
>   > |             |      | **Sprite[]** playerUnitSpritesOff                            |
>   > |             |      | **const string** playerAndEnemyUnitSpritesOnPath             |
>   > |             |      | **const string** playerUnitSpritesOffPath                    |
>
> ---



## BATTLE (BattleScene)

