# [Bolt Into Scripts]젤리키우기
https://www.youtube.com/watch?v=G6NronfnXfg&list=PLO-mt5Iu5TeZA0y889ZMi9wJafthif03i
 
![image](https://user-images.githubusercontent.com/50513500/153525148-3f373951-9716-4e24-976f-2a741424646c.png)

### 제작목적
* 볼트로 제작된 프로젝트를 보면서 구현할 주요 내용을 스크립트를 이용한 방식으로 재구성함으로써 개발 역량을 향상시키는 것 입니다. 

### 1. 도트 장면 만들기
![Jelly 1](https://user-images.githubusercontent.com/50513500/153527713-15a10b3b-1d03-4548-a3a5-86d14242f6b4.gif)

##### 구현
* 배경 이미지 배치
* 해상도 조정
* 배경 스크롤링 구현

### 2. 알아서 돌아다니는 젤리 AI
![Jelly 2](https://user-images.githubusercontent.com/50513500/153743114-8308a4f2-5153-4bd6-a3fc-3e73932f3812.gif)

##### 구현
* 젤리 이동 및 정지 로직 구현
* 맵의 경계 설정 및 젤리가 경계에 닿았을 때 중앙 방향으로 되돌아가는 로직 구현

### 3. 인터페이스 만들기
![Jelly3](https://user-images.githubusercontent.com/50513500/154681555-0cefaf2c-2e3d-4cda-9620-79737ce0e7df.gif)

##### 구현
* 캔버스 배치 및 조정
* 하단 UI 제작 & 배치
* 상단 재화 텍스트UI 제작 & 배치
* 재화 변동시 smoothstep을 사용한 애니메이션 효과 구현

### 4. 클리커 기능 구현
![Jelly 4](https://user-images.githubusercontent.com/50513500/155065006-21dfa1d1-35e4-4885-b188-357ba39badc2.gif)

##### 구현
* 젤리 클릭시 젤라틴 및 경험치 추가 구현
* 재화 최대치 구현
* 경험치 일정수치 이상 달성시 레벨업 구현

### 5. 판매를 위한 젤리 드래그 & 드랍
![5](https://user-images.githubusercontent.com/50513500/155927441-7897c20d-0488-4fd0-b5fa-c71f4d68c71b.gif)

##### 구현
* 젤리 드래그로 옮기는 기능 구현
* 경계 바깥으로 나갈 시 젤리 원위치 구현
* 젤리 판매 시 레벨과 종류에 따라 골드 획득 구현

### 6. UI창 구축하기
![Jelly6](https://user-images.githubusercontent.com/50513500/156875364-5abaeef7-50c7-425d-afe6-d2e6b00a3b2d.gif)

##### 구현
* 젤리 창 UI 구현
* 젤리공장 창 UI 구현
* 옵션 창 UI 구현
* 젤리창, 젤리공장 UI Move Up, Move Down 애니메이션 구현
* 옵션창 ON/OFF 구현
* 옵션창 ON인 동안 젤리 및 배경 정지 

### 7. 해금 시스템 만들기
![Jelly 7](https://user-images.githubusercontent.com/50513500/157710004-03a6784e-c942-4400-a9ee-0bba6e09686d.gif)

##### 구현
1. 젤리 해금 시스템 구현
2. 젤리창 좌우 이동 

### 8. 구매시스템 만들기

##### 구현
* 젤리 구매
* 구매시 젤리 스폰 구현
* 구매,판매시 데이터 자동저장

### 9. 업그레이드 시스템 구현
![9](https://user-images.githubusercontent.com/50513500/159616084-df899f3c-993b-4b7a-8a48-fc73d0aac9ac.gif)

##### 구현
* 플랜트(젤리 관리 능력치 - 수용량증가, 획득재화증가) 구현
* 플랜트에서 스킬 레벨업 가능
* 최대 젤리수에서 추가 젤리 구매 불가
