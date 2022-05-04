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

> Battle 필요한 작업들/ 화면 초기화, 유닛생성, 자원관리, 적 AI, 스테이지 클리어 유저 데이터.
>
> - SetUnitSprite
>
>   > unit Sprite manager 를 가진 오브젝트이다.
>
> - Master
>
>   > GameManager(BattleManager), ButtonScript , AI를 가진 오브젝트이다.
>
> - BlueCastle, RedCastle
>
>   > 각 진형과 관련된 Cost, CastleInfo script를 가지고 있다.
>
> - Canvas
>
>   > ,,?
>
> - SettingCanvas
>
>   > 게임화면과 canvas에 관한 것들.



### C# script

> - **BattleManager 클래스**
>
> > battle 시에 필요한 정보들을 초기화 및 관리하며 스테이지의 승패를 판단해준다.
> >
> > | 접근한정자 | 메소드 | 변수                                               | 설명                              |
> > | ---------- | ------ | -------------------------------------------------- | --------------------------------- |
> > | **public** |        | **static int** redUnitLevel                        | *변경 필요                        |
> > |            |        | **static int** redCurUnitNumber                    |                                   |
> > |            |        | **static int** redMaxUnitNumber                    |                                   |
> > |            |        | **static int** redCastleLevel                      | *변경 필요                        |
> > |            |        | **GameObject** canvasObject                        | minimap 유닛 생성 canvas          |
> > |            |        | **GameObject** hpcanvas                            | 유닛의 hpbar 생성 canvas          |
> > |            |        | **GameObject** victory                             | 스테이지 victory시 나오는 화면    |
> > |            |        | **GameObject** defeat                              | 스테이지 defeat 시 나오는 화면    |
> > |            |        | **GameObject** resetButton                         | 첫 화면으로 이동                  |
> > |            |        | **GameObject** controlSet                          | 업그레이드 관련 버튼들 관리       |
> > |            |        | **bool** win                                       | 승패 판단 변수                    |
> > |            |        | **bool** stageEnd                                  | 스테이지가 끝났음을 알려주는 변수 |
> > |            |        | **Sprite** empty                                   | empty sprite                      |
> > |            |        | **GameObject[]** unitslot = **new GameObject[8]**; | unitslot 8개를 담는 배열          |
> >
> > | 접근한정자  | 메소드                                                       |
> > | ----------- | ------------------------------------------------------------ |
> > | **private** | **void Result (bool win)**                                   |
> > |             | **void AllUnitEnableOff (GameObject[] playerUnits, GameObject[] enemyUnits)** |
> > |             | **void ResetButton()**                                       |
> > |             | **Sprite SlotSetting (GameObject gameObject, int idx)**      |
> >
> > | Function Name    |         parameter          | return | 설명                                                         |
> > | ---------------- | :------------------------: | :----: | ------------------------------------------------------------ |
> > | Result           |            bool            |  void  | 승패에 관한 값이 들어오면 화면상의 몇몇 오브젝트를 비활성화 시키고 승패관련 팝업창을 띄워준다. |
> > | AllUnitEnableOff | GameObject[]. GameObject[] |  void  | 파라미터로 들어온 오브젝트들을 비활성화 시켜준다.            |
> > | ResetButton      |            void            |  void  | 첫 화면으로 이동한다. scene 0  \| **변경필요.**              |
> > | SlotSetting      |      GameObject, int       |  void  | 유닛이 배정된 각 slot만의 sprite와 tag값을 초기화시켜준다,   |
>
> * **SlotScript**
>
> > 유닛이 배치된 슬롯에 대한 관리를 해준다. cost에 따른 sprite 변경.
> >
> > | 접근한정자 | 메소드 | 변수                            | 설명                                                         |
> > | ---------- | ------ | ------------------------------- | ------------------------------------------------------------ |
> > | **public** |        | **Image** coolTimeImage         | 기본 sprite 앞에 cooltime중임을 알려주는 sprite가 나타나 현재 상태를 보여준다. |
> > |            |        | **BattleManager** battleManager | battleManager의 stageEnd를 접근하기위해 변수로 받아왔다.     |
> > |            |        | **int** cost                    | 이 슬롯의 유닛의 cost 값                                     |
> > |            |        | **Sprite** limitStateSprite     | 유닛생성이 안되는 상황에서의 sprite.                         |
> > |            |        | **float** cooltime              | 이 슬롯의 유닛의 cooltime 값                                 |
> > |            |        | **BlueCost** blueCost           | update문에서 bluecost의 curcost을 계속 가져와야하기 때문에 bluecost를 받아왔다. |
> > |            |        | **ButtonScript** buttonScript   | 유닛생성은 이 클래스에 있다.                                 |
> > |            |        | **Sprite** rawSprite            | 기본적인 sprite                                              |
> >
> > | 접근한정자  | 메소드                   | 변수                        | 내용                                         |
> > | ----------- | ------------------------ | --------------------------- | -------------------------------------------- |
> > | **private** |                          | **bool** coolTimeLimitState | 쿨타임중에 클릭못하도록 막아놓는다.          |
> > |             |                          | **bool** coolTiming         | 쿨타임이 도는중                              |
> > |             |                          | **bool** activeButton       | cost에 따라 onsprite offsprite를 구분해준다. |
> > |             | **IEnumerator** CoolTime |                             |                                              |
> >
> > | Function Name | parameter |     return      | 설명                                                         |
> > | ------------- | :-------: | :-------------: | ------------------------------------------------------------ |
> > | CoolTime      | **float** | **IEnumerator** | cooltime동안 cooltimeimage의 fillamout를 줄여가며 시각적으로 남은 cooltime을 보여준다 |
>
> - **ButtonScript**
>
> > 슬롯을 클릭했을때 발생하는 유닛 객체화에 관한 함수가 들어있다.
> >
> > | 접근한정자 | 메소드                                         | 변수                              | 내용                                                       |
> > | ---------- | ---------------------------------------------- | --------------------------------- | ---------------------------------------------------------- |
> > | public     |                                                | **BattleManager** battleManager   | stageEnd 상황에서는 유닛생성을 안되게 막기위해 받아온 변수 |
> > |            |                                                | **BlueCastleInfo** blueCastleInfo | castleInfo의 cur,max Population과 curcost 정보를 받아옴.   |
> > |            | **void** Button (**MyType.UnitType** unitType) |                                   |                                                            |
> >
> > | 접근한정자 | 메소드                                                       | 변수                                        | 내용                           |
> > | ---------- | ------------------------------------------------------------ | ------------------------------------------- | ------------------------------ |
> > | private    |                                                              | **string[]** uniPrefabPath = new string[]{} | unitPrefab경로를 지정해놓는다. |
> > |            | **void** CreateUnitPosition(**GameObject** target, **GameObject** positionObject) |                                             |                                |
> > |            | **void** BluePathY(**int** bluePath)                         |                                             |                                |
> >
> > | Function Name      |                      parameter                      |  return  | 설명                                                         |
> > | ------------------ | :-------------------------------------------------: | :------: | ------------------------------------------------------------ |
> > | CreateUnitPosition | **GameObject** target, **GameObject** positionObjec | **void** | target을 객체화시키고 미니맵에 위치를 알려주는 객체를 생성한다. |
> > | BluePathY          |                  **int** bluePath                   | **void** | 입력받은 값으로 미니맵위치를 설정한다.                       |
> >
> > 



