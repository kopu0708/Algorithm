# 미리 보는 코딩 오답 노트 
진짜 시작하기 전에 자주 실수하는 유형과 실제로 유용한 팁들을 알아보자.

### 1. 시간 초과의 원인을 찾아 해결하기 
코딩 테스트를 하다보면 가장 많이 마주치는 문제는 바로 시간 초과이다. (실제로 나도 많이는 아니지만 몇번 겪었다.)

이럴 때는 입력과 출력 방식부터 최적화 할 수 있는지 점검해 보는 게 좋다고 한다. 

파이썬은 input(), print()로 입 출력을 하는데 이 대신에 sys.stdin.readline()과 sys.stdout.write()를 활용하는게 훨씬 빠르다고 한다. 

시간 초과가 나는 경우 로직의 시간 복잡도를 점검해 제한 시간안에 내 로직이 문제를 해결 할 수있는지를 먼저 점검하자

그리고 입출력 방식의 최적화를 고려해야한다. 성능에 문제가 있는 것은 아니지만 데이터 양이 많아지면 점점 큰 차이를 보인다. 

나는 c#을 공부하니 c#인 경우에는 어떻게 해야하나 AI에게 물어보니 C#도 마찬가지라고 한다. 

```C#
using System;
using System.IO;

class Program
{
    static void Main()
    {
        // 입력: StreamReader (파이썬의 sys.stdin.readline과 같은 역할)
        var input = new StreamReader(Console.OpenStandardInput());

        // 출력: StreamWriter (파이썬의 sys.stdout.write와 같은 역할)
        var output = new StreamWriter(Console.OpenStandardOutput());
        output.AutoFlush = false;  // 핵심! 매번 즉시 쓰지 않고 버퍼에 모음

        int n = int.Parse(input.ReadLine());
        for (int i = 0; i < n; i++)
        {
            output.WriteLine(i);  // 버퍼에 쌓이기만 함, 아직 출력 안 됨
        }

        output.Flush();  // 마지막에 한 번에 다 쏟아냄 (필수!)
    }
}
```
위와 같이 항상쓰던 Console.ReadLine(), Console.WriteLine() 과 다른 StreamReader, StreamWriter가 있다. 

코드가 좀 더 복잡해지고 불편하지만 시간 초과가 나는 경우 이를 이용해 최적화가 가능 할 것이다.

그러면 왜 이런 차이가 생기는 건지 알아보자 원리는 파이썬과 같다고 한다. 

Console.ReadLine()이 호출될 때마다. 한 줄을 읽어 끝의 개행 문자를 제거한 문자열을 반환하며, 숫자 변환 등 추가 파싱은 호출자가 직접 처리해야한다.

반면에 StreamReader는 입력 버퍼에서 한 줄을 읽어 개행 문자로 구분하여 꺼내준다. 즉 필요할때 마다 가져와 쓰기 VS 미리 다 가져와서 바로 꺼내주기라고 생각하자

Console.WriteLine()은 호출할 때마다 즉시 출력을 내보낸다(AutoFlush = true). 

호출이 많아지면 이 "매번 즉시 출력"하는 과정 자체가 병목이 된다.

StreamWriter는 AutoFlush를 false로 설정하면 출력을 버퍼(임시 저장소)에 모아뒀다가 Flush()를 호출할 때 한 번에 내보낸다. 

그래서 호출 횟수가 많을수록 StreamWriter 쪽이 유리해진다.  
```C#
using System;
using System.IO; //stream 이거 쓸려면 이거 있어야 함 
class Program
{
    static void Main()
    {
        //일반적인 방식
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine(a);

        // 더 빠른 입출력
        var input = new StreamReader(Console.OpenStandardInput()); // 1. 객체 생성
        int b = int.Parse(input.ReadLine());                        //2. 그 객체로 읽고 파싱
        var output = new StreamWriter(Console.OpenStandardOutput()); // 3. 출력 객체 생성
        output.AutoFlush = false;                                     // 4. 버퍼링 켜기
        output.WriteLine(b);                                          // 5. 버퍼에 씀 (아직 출력 안 됨)
        output.Flush();                                                // 6. 진짜로 출력
    }
}
```
확실히 어색하다. 아직 초면이라 자주 봐야할 듯 
### 2. 인덱스에 의미 부여하기
코딩 테스트에서 가장 많이 쓰이는 자료구조는 리스트 이다. 그리고 리스트는 보통 인덱스로 데이터에 접근한다.

인덱스는 일반적으로 몇 번째 데이터인지 나타내는 역할이지만 상황에 따라 해싱개념을 적용해 단순한 위치가 아닌 특정한 의미를 지닌 값으로 활용이 가능하다.

딕셔너리가 있잖아요? 

맞는데 왜 리스트를 쓰냐면 속도 때문이다. 코딩 테스트에는 보통 범위가 정해져 있기 때문에 딕셔너리보다 배열이 더 빠르고 메모리도 적게 쓴다.

반면 범위가 크거나 예측 불가능한 값(예: 문자열 전체, 매우 큰 수)을 키로 써야 하면 딕셔너리가 필요하다.

그럼 이제 의미를 부여한다는게 뭔지 보자 
```C#
// 알파벳 빈도수 세기 — 인덱스 0~25가 각각 'a'~'z'를 의미
string s = "hello";
int[] count = new int[26];

foreach (char c in s)
{
    count[c - 'a']++;  // 'h'는 인덱스 7, 'l'은 인덱스 11...
}

Console.WriteLine(count['l' - 'a']);  // 2
```
int형 배열을 만들었는데 각 알파벳에 대응되는 번호를 부여해 그 숫자를 샜다. 즉 해당 인덱스의 번호는 단순히 몇번째가 아니라 해당 인덱스의 알파벳이라고 보면된다.

그리고 그 인덱스의 데이터 값은 그 알파벳이 얼마나 나왔는지를 저장하게 된다.

"인덱스에 의미 부여하기"의 대표적인 활용 예가 계수 정렬(Counting Sort)이다. 인덱스 자체가 정렬된 순서라는 걸 이용해서, 비교 연산 없이 빈도수만 세서 정렬하는 기법이다.

이와 같이 의미를 부여하는 걸 해싱 기법이라고 하며 이와 같이 상황에 따른 인덱스에 의미 부여가 중요하다.

### 3. 나머지 연산의 중요성 
코딩 테스트에는 정답을 나머지 값으로 요구하는 경우가 종종 있다. 큰 수의 연산을 효율적으로 처리하고, 나머지 연산의 수학적 성질을 활용할 수 있는지를 확인하기 위해서이다.

나머지 연산은 나눗셈을 제외하고는 덧셈, 뺄셈, 곱셈의 분배 법칙이 성립한다.

덧셈의 분배 법칙 성립 -> (A+B)%C = (A%C + B%C) %C 

뺄셈의 분배 법칙 -> (A-B)%C = (A%C - B%C) %C 

뺄셈은 음수가 나올 수 있으므로 실전에서는:
(A-B)%C = ((A%C - B%C) + C) % C   ← +C로 음수 방지

곱셈의 분배 법칙 -> (A*B)%C = (A%C)*(B%C) % C 

나눗셈의 분배 법칙은 성립하지 않는다. -> (A/B)%C != (A%C)/(B%C) % C  

마지막에만 %을 적용시키면 나머지를 계산할 수 있지만 숫자가 커지면 속도가 느려지고 시간 초과에 걸릴수가 있다.

그래서 중간 과정마다 나머지 연산을 적용하는 습관이 중요하다.

예를 들어보자 '1부터 100,000까지 곱한 값을 1,000,000,007로 나눈 나머지를 구하시오' 라는 문제를 시도해보자 
```C#
class Program
{
    static void Main()
    {
        long result = 1;
        int mod = 1000000007; 

        for(int i = 1; i<=1000000; i++)
        {
            result *= i;
        }

        result %= mod;  

        Console.WriteLine(result);
    }
}
```
위에 실행하면 0이 나온다. 오버플로우 일어나서 이렇듯 한번에 곱해서 한번에 나눌려고 하면 문제가 일어난다.

곱셈을 수행할 때마다 나머지 연산을 수행하는 로직으로 바꾸어 보자 
```C#
static void Main()
{
    long result = 1;
    int mod = 1000000007; 

    for(int i = 1; i<=1000000; i++)
    {
        result = (result * i) % mod;
    }

    Console.WriteLine(result);
}
```
이번에는 정상적으로 코드가 작동을 한다. 이렇게 중간 중간 나머지 연산이 왜 중요한지 알 수 있었다. 근데 솔직히 의심스럽지 않는가? 두 연산의 결과가 같은지 말이다.

10! 정도로 수를 줄여 계산하면 나머지 같다는 걸 볼 수가 있다.  

핵심은 나머지 연산을 할 때에는 분배 법칙을 이용해서 숫자를 자료형을 벗어나지 않게 중간 중간 나머지 연산을 해줘야 한다는 것이다.
### 4. 정렬 기초 다지기 
대학교 1학년 C를 처음 배울때가 생각난다. 그 때 기본문법을 어느정도 익히고 아마 포인터로 넘어가기 전에 했었던 것 같다. 

그 때는 버블 정렬이라는 걸 처음 배웠었는데 이거 할 줄 알면 다 만들 줄 알았었던 기억이 난다. (그리고 이때 교수가 나보고 잘한다 해서 지금까지 하고 있는 거기도 하고) 

지금 생각하면 새발의 피에 불과하는 내용이지만 중요한 내용임에는 변함없다.

먼저 정렬은 거의 모든 알고리즘의 출발점이자 핵심이다. 아무래도 대용량의 데이터를 다루다 보면 전처리가 필수적인데 이 전처리 과정이 정렬을 하는 일이기 때문이지 않을까

오름차순 정렬은 데이터의 가장 작은 값부터 시작해서 마지막에는 가장 큰 값이 오도록 하는걸 말한다. (ex. 1,2,3,4,5)

이런 정렬을 수행하는 알고리즘을 만들필요는 없다. 내가 아는 한 거의 모든 언어는 sort() 같은 메소드를 제공해주기 때문이다. 

그럼에도 이 메소드들이 내부적으로 어떻게 돌아가는냐에 따라 시간복잡도가 다르고 상황에 따라 유리한 방법을 판단할 수 있어야 하기에 정렬 알고리즘을 공부해야한다.
```c#
int[] arr = { 5, 3, 1, 4, 2 };
Array.Sort(arr);  // 배열 오름차순 정렬
// arr = { 1, 2, 3, 4, 5 }

List<int> list = new List<int> { 5, 3, 1, 4, 2 };
list.Sort();  // List도 마찬가지
```
위 코드는 오름차순으로 정렬해주는 sort() 메소드이다. 원본을 수정한다. 
```c#
using System;
using System.Linq;

int[] original = { 5, 3, 1, 4, 2 };

int[] sorted = original.OrderBy(x => x).ToArray();

Console.WriteLine(string.Join(",", original));  // 5,3,1,4,2  ← 원본 그대로
Console.WriteLine(string.Join(",", sorted));    // 1,2,3,4,5  ← 새로 만든 정렬본
```
원본을 건드리지 않고 정렬된 복사본을 만드는 방법은 위와 같이 LINQ가 필요하다. 교제를 보니 파이썬은 sorted()라고 쓰면 되는 듯 한데 c#은 OrderBy()이다. 

내림차순 정렬을 원한다면 OrderByDescending()을 쓰거나 
```C#
using System;
using System.Linq;

int[] original = { 5, 3, 1, 4, 2 };

int[] sorted = original.OrderBy(x => -x).ToArray(); // 이렇게 식을 수정하면되지 않을까 문자형은 안되겠지만

Console.WriteLine(string.Join(",", original));  
Console.WriteLine(string.Join(",", sorted)); // 5,4,3,2,1    
```
원본 내림차순은 Reverse()를 사용해도 되고 List 자료형인 경우도 마찬가지이다.

이처럼 다양한 정렬방법을 알아두는 것이 중요하다.

### 다중 조건 정렬 익히기
정렬을 할때는 조건을 여러개가 필요할 때가 있다. SQLD 공부했을 때에도 정렬 조건을 여러개 주지 않았던가 

파이썬에서는 튜플 기반 정렬과 딕셔너리 기반 정렬이 있다고 한다. 데이터를 튜플로 구성한 뒤 정렬 메소드를 쓰는 방식인데 

C#은 아까봤던 OrderBy()에 ThenBy()를 체인으로 연결하는 방식을 쓴다.

```C#
(int, int)[] Score = new[]
{
    (30,40), //국어, 수학 점수 라고 치자 
    (50, 60),
    (70, 80)
};

var sorted = Score
    .OrderBy(x => x.Item1)  // 1순위 국어 점수 오름차순,
    .ThenBy(x => x.Item2);  //2순위 영어 점수 오름차순
```
이런 식으로 가독성 좋게 조건을 줄 수가 있다. 
```c#
// 딕셔너리도 방식은 동일 — KeyValuePair를 기준으로
Dictionary<string, int> scores = new Dictionary<string, int>
{
    { "철수", 85 }, { "영희", 90 }, { "민수", 85 }
};

var sortedScores = scores
    .OrderBy(kvp => kvp.Value)   // 1순위: 점수 오름차순
    .ThenBy(kvp => kvp.Key);     // 2순위: 이름 오름차순
```
이게 c#에서 가장 일반적인 방법이다.         
### 이차원 리스트 다루기 
코테에는 꼭 알아야 할게 또 있는데 바로 2차원 배열이다. 선언과 저장, 활용 방법을 알아야 문제를 풀 수 있을 것이다.

근데 이미 했었으니깐 간단하게 보고 넘어가자 

- 선언법
``` C#
int[,] grid = new int[N, M];  // N행 M열
```

- 초기화
```c#
// 크기만 정하고 나중에 채우기
int[,] grid = new int[3, 3];

// 선언과 동시에 값 채우기
int[,] grid2 = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};
```

- 접근법
```C#
grid[0, 0] = 10;        // 0행 0열에 값 저장
int value = grid[1, 2]; // 1행 2열 값 읽기

// 전체 순회
for (int i = 0; i < grid.GetLength(0); i++)      // 행
{
    for (int j = 0; j < grid.GetLength(1); j++)  // 열
    {
        Console.Write(grid[i, j] + " ");
    }
    Console.WriteLine();
}
```


