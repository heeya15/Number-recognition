# Number-recognition
- FCM 및 Fuzzy max-min 을 이용한 Neural -Netework 숫자인식 입니다.
- 저의 주제는 FCM 및 Fuzzy max-min 을 이용한 Neural -Netework 숫자인식 입니다.

# 목차는 
1. 작품소개 
2. 개발에 사용된 처리과정 및 알고리즘 분석
  - 1)Preprocessing 
  - 2)FCM
  - 3)MIN-MAX- Normalization 
3. 실제구현
4. 결론 및 개선방향 순으로 진행되겠습니다 .
5. 먼저 작품소개 

- 사람의 손 글씨의 숫자를 분류하는데 사람마다 글자체가 다르고 , 한쪽으로 치우쳐져서 
- 숫자를 적을 수도 있는데 그것을 해결하기 위해 해당 글자색이 검은색 영역 
- 즉, 관심영역을 추출해서 해당하는 숫자를 인식하도록 처리하게 만든 프로그램이다. 

# 숫자 인식 Flow Chart

개발에 사용된 초기과정 및 알고리즘 분석 1) 
- Preprocessing(전처리과정)으로 
  처음에 이미지 그레이를 하고, Max_Min 이진화과정을 거친뒤 
  해당 숫자 영역만 관심영역으로 추출한다.
- 다음 FCM 으로 
  Fuzzy C-means + Euclidean distance 알고리즘을 사용하였는대
  FCM  동일한 하나의 클러스터에 속해져 있는 각각의 데이터점을 소속도 에의 해서 
  클러스터에 대한 데이터의 소속도를 일일이 열거한 데이터 분류 방법이다. 
  유클리디안 거리는 두 점사이의 거리를 계산할때 쓰이는 방법으로 소속도를 구할 때 적용

# FCM을 응용한 4방향 군집분석을 하였는데 
- 제일 위쪽 좌상단, 우측 상단 , 제일 아래쪽 좌 하단, 우측 하단으로 클러스터를 정하고 
  이미지에 대한 소속도를 구해 특징을 추출하였습니다.
- 소속도를 구하는데 데이터와 클러스터의 거리를 유클리디안 공식을 이용하여 소속도를 구하였습니다.
- 퍼지 군집 모형은 아래 두개의 분할 조건을 만족해야 하는데
  데이터가 각 군집 클러스터에 속할 가능성의 가중값 합은 1이고
  각 군집 클러스터는 하나 이상의 데이터가 0이아닌 가중값을 가지며, 그 군집의 모든 가중 값이 1이 될수는 없다 라는 조건을 가집니다 
- 그래서 4방향 소속도라서 가중치가 크게 차이나지 않는 문제가 생겼는데 
   유클리디안 거리로 구한 소속도를 Min-Max-Normalization 을 하여 소속도를 극적으로 차이나게 하였습니다
   즉, 정규화로 클러스터에 대해 각각의 최소값 0 최대값 1 그리고 다른 값들은  0과 1사이의 값으로 변환하였습니다. 

# 실제 구현부분
실제 구현 결과는 보시는 봐와 같이 아까 각데이터와 해당 클러스터 영역의 거리값을 구한 소속도를 
보시는 봐와 같이 보실수 있으며 각 숫자가 인식한 결과들도 볼 수 있습니다.
최종적으로 해당 숫자에 대한 인식 결과가 제일 높은 숫자를 인식숫자로 판단하여 출력하도록 하였습니다.
# 결론 및 개선방향으로는
 1. 해당 이미지가 배경이 하얀색인 경우를 가정하여 학습하였기 때문에 배경에 상관없이 숫자 인식을 하게끔 연구해 보겠습니다.
 2. 심층 신경망으로 학습을 하게끔 최종 출력값과 실제값의 오차가 최소가 되도록 
    심층 신경망을 이루는 각 층에서 입력되는 값에 곱해지는 가중치와 바이어스를 계산하여 결정할 수 있게끔 
    역전파(Backpropagation) 알고리즘 개념도 넣으면 loss 값이 줄어들어 숫자 인식이 훨씬 잘 될 거 같아 공부해 보도록 하겠습니다.
# 느낀점
- 이번 퍼지 기말 프로젝트를 팀원 없이 혼자서 할 생각에 처음에 너무 막막하고 어떻게 해야 할지 몰랐었는데, 
  교수님께 배웠던 신경망 구조와, FCM 개념들을 천천히 차근차근 공부해서 모르는 것들도 검색과 주변 친구들에게 물어보면서 
  한 단계씩 해결해 나가니 비록 성능 면에선 아직 떨어지지만 만들면서 공부가 정말 많이 된 것 같아 뿌듯합니다. 
