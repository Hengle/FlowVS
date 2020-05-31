## Flow - visual scripting editor

#### 구조

![image](https://user-images.githubusercontent.com/31693348/83349677-b7e39a00-a371-11ea-8fa5-5e0d2a4e45f1.png)

에디터의 실행부와 에디터부를 dll로 모듈화 되어있습니다. 사용자는 제공되는 dll를 이용해 자신만의 액션, 컨디션을 제작해 원하는 방향으로 프로토타입 프로젝트를 시연해볼 수 있습니다.



#### 사용방법

1. Hierarchy 생성

   ![image](https://user-images.githubusercontent.com/31693348/83349684-c5008900-a371-11ea-88d5-b0a95a473f83.png)

   - New Hierarchy란에 생성할 Hierarchy 이름을 설정하고 Create버튼을 눌러주면 새로운 Hierarchy가 생성됩니다.

2. 액션추가

   ![image](https://user-images.githubusercontent.com/31693348/83349720-f8dbae80-a371-11ea-8e29-84755c06a6f0.png)

   - 원하는 액션을 선택하여 추가합니다.
   - 액션은 사용자가 직접 제작해서 (ActionView, ActionExecute를 상속받아서 제작) 원하는 액션을 추가하거나 삭제할 수 있습니다.

3. 브랜치 추가

   ![image](https://user-images.githubusercontent.com/31693348/83349691-d6e22c00-a371-11ea-998b-7f0dc2889e6e.png)

   - 조건에 따른 분기를 생성합니다
   - 해당 조건이 만족이될 때 다음 액션이 실행되도록 구성되어있습니다.
   - 액션과 같이 사용자가 직접 제작해서(ConditionView, ConditionExecute를 상속받아서 제작) 원하는 조건을 추가하거나 삭제할 수 있습니다

4. 새로운 노드 추가

   ![image](https://user-images.githubusercontent.com/31693348/83349730-0e50d880-a372-11ea-99c6-83c1b9a8e86b.png)

   - 노드를 새로 만들어 순차적으로 실행시킬 수 있습니다.

5. 노드간 연결

   ![image](https://user-images.githubusercontent.com/31693348/83349739-19a40400-a372-11ea-88e1-d2b4fd840859.png)

   - 초록색 + 버튼을 눌러 노드와 노드사이의 연결을 생성할 수 있습니다
   - 초록색 + 버튼은 브랜치별로 나누어져있어 해당 브랜치 조건이 실행됐을때에 맞는 다음 노드로 넘어가게 됩니다.