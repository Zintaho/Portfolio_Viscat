# Portfolio_Viscat
날 키울거냥? 프로젝트에서, 제가 담당한 부분의 소스 코드 입니다.
(Unity3D와 C#을 처음 배울때의 코드이며 보완을 진행할 예정입니다.)

전체 프로젝트는 아래 링크를 참조해 주십시오.
https://github.com/Zintaho/Viscat

프로젝트의 이해를 돕기 위한 기획서는 아래를 참고해 주십시오 (기획 작성자는 제가 아닙니다.)
https://drive.google.com/file/d/0B9aj10mhLz9QdVdUdW5PZHBQVjg/view?usp=sharing

[SelectCat Folder]


>CatSelect.cs : 게임 시작 시 고양이를 선택

[Main Folder]


>BuyManger.cs : 상점에서의 아이템 구매 행위에 대한 매니저

>CatManger.cs : 메인화면에서의 고양이 상태 매니저

>GameManager.cs : 메인화면 전체에 대한 매니저

>GiveItem.cs : 고양이 에게 인벤토리에서 아이템을 건내줌

>Item.cs : 아이템 클래스

>ItemManager.cs : 아이템 목록에 관한 매니저

>ShopManager.cs : 상점에 대한 매니저

>TextBalloonManager.cs : 말풍선에 대한 매니저

>TitleTextManager.cs : 플레이어의 칭호에 대한 매니저


[Main/Uis Folder]


>GaugeManager.cs : 고양이의 상태 게이지에 대한 매니저

>>AffineGauges.cs , HealthGauges.cs, Hungergauges.cs : 각 상태 게이지에 대한 스크립트(GaugeManager를 상속)

>UIValue.cs : 수치를 표현하는 UI들의 Super Class

>>BellValue.cs, CoinValue.cs, FiveScore.cs, PikaScore.cs, TowerScore.cs : 각 수치 에 대한 Child Class (UIValue 를 상속)


>Gauges.cs : 게이지들

>LevelText.cs : 플레이어 레벨 표시

>SoundControl.cs : 음량 조절



