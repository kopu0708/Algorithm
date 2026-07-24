# Algorithm

관련 레포: [C# 문법 학습 노트](https://github.com/kopu0708/C-charp)
---

Do it 코딩테스트 파이썬 교재로 알고리즘 공부하기 근데 c#으로 할거임 

백준이 한때 서비스 중단 이슈가 있었지만, 문제 자체는 책에 포함되어 있어 학습에 지장 없을듯  

파이썬 책인데 왜 c#으로 하느냐는 C#이 더 익숙하고 유니티 쓸려면 C#을 잘 알아야 하기 때문이다. 사실 둘다 객체지향 언어라 큰 상관 없을 듯 

----

## 시간 복잡도 표기법 알아보기 
알고리즘에서 시간 복잡도는 주어진 문제를 해결하기 위한 연산 횟수를 이야기한다. 

3가지 유형이 있다고 함 
- 빅-오메가 : 최선일 때(best case)의 연산 횟수를 나타낸 표기법 
- 빅-세타   : 보통일 때(average case)의 연산 횟수를 나타낸 표기법 
- 빅-오     : 최악일 때(worst case)의 연산 횟수  

1~100까지의 사이의 무작윗값을 찾아 출력하는 코드는 빅-오메가일 경우 1번, 빅-세타는 N/2, 빅-오는 N번이라고 한다.
```C#
using System;
class Program
{
    static void Main()
    {
        Random random = new Random();
        int target = random.Next(1, 101);  // 찾을 목표값 (미리 정해져 있다고 가정)

        int[] arr = new int[100];
        for (int i = 0; i < 100; i++)
            arr[i] = i + 1;  // 1~100이 순서대로 들어있는 배열

        int count = 0;  // 연산 횟수 세기
        for (int i = 0; i < arr.Length; i++)
        {
            count++;
            if (arr[i] == target)
            {
                Console.WriteLine($"{target}을 {count}번 만에 찾음");
                break;
            }
        }
    }
}
```



