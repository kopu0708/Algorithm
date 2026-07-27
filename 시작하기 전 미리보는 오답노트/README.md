# 미리 보는 코딩 오답 노트

> 진짜 시작하기 전에 자주 실수하는 유형과 실제로 유용한 팁들을 알아보자.

---

## 📚 목차

- [1. 시간 초과의 원인을 찾아 해결하기](#1-시간-초과의-원인을-찾아-해결하기)
- [2. 인덱스에 의미 부여하기](#2-인덱스에-의미-부여하기)
- [3. 나머지 연산의 중요성](#3-나머지-연산의-중요성)
- [4. 정렬 기초 다지기](#4-정렬-기초-다지기)
- [다중 조건 정렬 익히기](#다중-조건-정렬-익히기)
- [이차원 리스트 다루기](#이차원-리스트-다루기)

---

## 1. 시간 초과의 원인을 찾아 해결하기

코딩 테스트에서 가장 많이 마주치는 문제는 **시간 초과**다. (실제로 몇 번 겪었다.)

이럴 땐 입력·출력 방식부터 최적화할 수 있는지 점검하는 게 좋다. 파이썬은 `input()`, `print()` 대신 `sys.stdin.readline()`, `sys.stdout.write()`를 쓰는 게 훨씬 빠르다고 알려져 있다.

**점검 순서:**
1. 로직의 시간 복잡도부터 점검 — 제한 시간 안에 풀 수 있는 복잡도인가?
2. 입출력 방식 최적화 — 데이터 양이 많아질수록 차이가 커진다.

**C#도 마찬가지다.**

```csharp
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

**왜 차이가 나는가**

- `Console.ReadLine()` — 호출될 때마다 한 줄을 읽어 개행 문자를 제거한 문자열을 반환. 숫자 변환 등 추가 파싱은 직접 처리해야 함.
- `StreamReader` — 입력 버퍼에서 한 줄을 꺼내줌. **필요할 때마다 매번 OS에 요청(Console) vs 미리 크게 받아와서 버퍼에서 꺼내주기(StreamReader)** 라고 생각하면 된다.
- `Console.WriteLine()` — 호출할 때마다 즉시 출력을 내보낸다(`AutoFlush = true`). 호출이 많아지면 이 "매번 즉시 출력"하는 과정 자체가 병목이 된다.
- `StreamWriter` — `AutoFlush = false`로 설정하면 출력을 버퍼에 모아뒀다가 `Flush()` 호출 시 한 번에 내보낸다. 호출 횟수가 많을수록 유리해진다.

```csharp
using System;
using System.IO;  // Stream 쓰려면 필요

class Program
{
    static void Main()
    {
        // 일반적인 방식
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine(a);

        // 더 빠른 입출력
        var input = new StreamReader(Console.OpenStandardInput());   // 1. 객체 생성
        int b = int.Parse(input.ReadLine());                          // 2. 그 객체로 읽고 파싱
        var output = new StreamWriter(Console.OpenStandardOutput()); // 3. 출력 객체 생성
        output.AutoFlush = false;                                     // 4. 버퍼링 켜기
        output.WriteLine(b);                                          // 5. 버퍼에 씀 (아직 출력 안 됨)
        output.Flush();                                                // 6. 진짜로 출력
    }
}
```

> 확실히 어색하다. 아직 초면이라 자주 봐야 할 듯.

---

## 2. 인덱스에 의미 부여하기

코딩 테스트에서 가장 많이 쓰이는 자료구조는 리스트다. 리스트는 보통 인덱스로 데이터에 접근하는데, 인덱스는 원래 "몇 번째 데이터인지"를 나타내지만 **해싱 개념을 적용하면 단순 위치가 아닌 특정한 의미를 지닌 값**으로 활용할 수 있다.

**"딕셔너리가 있잖아요?"**

맞지만 리스트(배열)를 쓰는 이유는 **속도** 때문이다. 코딩 테스트는 보통 범위가 정해져 있어서 딕셔너리보다 배열이 더 빠르고 메모리도 적게 쓴다. 반면 범위가 크거나 예측 불가능한 값(문자열 전체, 매우 큰 수)을 키로 써야 하면 딕셔너리가 필요하다.

**의미를 부여한다는 게 뭔지 보면:**

```csharp
// 알파벳 빈도수 세기 — 인덱스 0~25가 각각 'a'~'z'를 의미
string s = "hello";
int[] count = new int[26];

foreach (char c in s)
{
    count[c - 'a']++;  // 'h'는 인덱스 7, 'l'은 인덱스 11...
}

Console.WriteLine(count['l' - 'a']);  // 2
```

`int` 배열을 만들었는데, 각 알파벳에 대응되는 번호를 부여해서 그 숫자를 셌다. 즉 해당 인덱스의 번호는 단순히 몇 번째가 아니라 **해당 인덱스의 알파벳**이라고 보면 된다. 그리고 그 인덱스의 데이터 값은 그 알파벳이 얼마나 나왔는지를 저장한다.

> "인덱스에 의미 부여하기"의 대표적인 활용 예가 **계수 정렬(Counting Sort)** 이다. 인덱스 자체가 정렬된 순서라는 걸 이용해서, 비교 연산 없이 빈도수만 세서 정렬하는 기법이다.

이와 같이 의미를 부여하는 걸 **해싱 기법**이라 하며, 상황에 따른 인덱스 의미 부여가 중요하다.

---

## 3. 나머지 연산의 중요성

코딩 테스트에는 정답을 나머지 값으로 요구하는 경우가 종종 있다. 큰 수의 연산을 효율적으로 처리하고, 나머지 연산의 수학적 성질을 활용할 수 있는지 확인하기 위해서다.

나머지 연산은 나눗셈을 제외하고는 덧셈, 뺄셈, 곱셈의 분배 법칙이 성립한다.

```
덧셈: (A+B)%C = (A%C + B%C) %C
뺄셈: (A-B)%C = (A%C - B%C) %C
      → 음수가 나올 수 있으므로 실전에서는:
      (A-B)%C = ((A%C - B%C) + C) % C   ← +C로 음수 방지
곱셈: (A*B)%C = (A%C)*(B%C) % C
나눗셈: 분배 법칙 성립 안 함 → (A/B)%C != (A%C)/(B%C) % C
```

마지막에만 `%`을 적용해도 나머지는 계산할 수 있지만, 숫자가 커지면 오버플로우가 나서 문제가 생긴다. 그래서 **중간 과정마다 나머지 연산을 적용하는 습관**이 중요하다.

**예제 — '1부터 1,000,000까지 곱한 값을 1,000,000,007로 나눈 나머지를 구하시오'**

```csharp
// 실패 버전 — 마지막에만 나머지 연산
class Program
{
    static void Main()
    {
        long result = 1;
        int mod = 1000000007;

        for (int i = 1; i <= 1000000; i++)
        {
            result *= i;
        }

        result %= mod;
        Console.WriteLine(result);  // 0 이 나온다!
    }
}
```

**왜 0이 나오는가:** `long`은 64비트라 담을 수 있는 범위가 정해져 있다. 계속 곱하다 보면 어느 순간 **오버플로우**가 나서 초과분이 잘려나가는데, 1~1,000,000 사이에는 2의 배수가 워낙 많아서 곱한 값이 정확히 2^64의 배수가 되는 시점이 반드시 온다. 그 순간 결과가 `0`이 되고, 이후로 뭘 곱해도 계속 `0`으로 남는다.

```csharp
// 성공 버전 — 곱할 때마다 나머지 연산
static void Main()
{
    long result = 1;
    int mod = 1000000007;

    for (int i = 1; i <= 1000000; i++)
    {
        result = (result * i) % mod;  // 매번 곱하고 바로 나머지
    }

    Console.WriteLine(result);
}
```

`result`가 매번 나머지 연산을 거치므로 항상 `mod` 미만(10억 미만)으로 유지된다. `result × i`의 최대값도 대략 10억 × 백만 = 10^15(천조) 수준이라 `long`의 한계(약 9.2×10^18)보다 훨씬 작아서 오버플로우가 나지 않는다.

**정말 같은 결과가 나올까? — 직접 검증**

10!(=3,628,800) 정도로 수를 줄이면 두 방식(마지막에만 나머지 vs 매번 나머지) 모두 오버플로우 없이 계산되고, 결과가 정확히 일치하는 걸 확인할 수 있다. 이게 가능한 이유는 곱셈의 분배 법칙이 성립하기 때문이다 — 매번 나머지 연산을 해도, 수학적으로는 "끝까지 다 곱한 다음 딱 한 번 나머지 연산한 것"과 같은 값이 나온다.

> 핵심은 나머지 연산을 할 때 분배 법칙을 이용해서, 숫자가 자료형을 벗어나지 않게 중간중간 나머지 연산을 해줘야 한다는 것이다.

---

## 4. 정렬 기초 다지기

정렬은 거의 모든 알고리즘의 출발점이자 핵심이다. 대용량 데이터를 다룰 때 전처리가 필수적인데, 이 전처리 과정이 곧 정렬이기 때문일 것이다.

오름차순 정렬은 가장 작은 값부터 시작해서 가장 큰 값으로 끝나는 것을 말한다 (ex. 1,2,3,4,5).

이런 정렬 알고리즘을 직접 만들 필요는 없다. 거의 모든 언어가 `sort()` 같은 메서드를 제공하기 때문이다. 그럼에도 이 메서드들이 내부적으로 어떻게 동작하느냐에 따라 시간복잡도가 다르고, 상황에 따라 유리한 방법을 판단할 수 있어야 하기에 정렬 알고리즘을 공부해야 한다.

### 원본을 수정하는 정렬

```csharp
int[] arr = { 5, 3, 1, 4, 2 };
Array.Sort(arr);  // 배열 오름차순 정렬
// arr = { 1, 2, 3, 4, 5 }

List<int> list = new List<int> { 5, 3, 1, 4, 2 };
list.Sort();  // List도 마찬가지
```

### 원본을 건드리지 않는 정렬 (복사본 생성)

원본을 그대로 두고 정렬된 복사본을 만들려면 **LINQ**의 `OrderBy()`가 필요하다. 파이썬은 `sorted()`, C#은 `OrderBy()`.

```csharp
using System;
using System.Linq;

int[] original = { 5, 3, 1, 4, 2 };
int[] sorted = original.OrderBy(x => x).ToArray();

Console.WriteLine(string.Join(",", original));  // 5,3,1,4,2  ← 원본 그대로
Console.WriteLine(string.Join(",", sorted));    // 1,2,3,4,5  ← 새로 만든 정렬본
```

**내림차순:**

```csharp
// 방법 1 — OrderByDescending() 사용
int[] sorted = original.OrderByDescending(x => x).ToArray();

// 방법 2 — 식을 음수로 뒤집기 (숫자에만 가능, 문자열은 불가)
int[] sorted2 = original.OrderBy(x => -x).ToArray();
// 5,4,3,2,1
```

원본을 내림차순으로 만들고 싶으면 `Array.Sort()` 후 `Array.Reverse()`를 쓰면 된다. `List<T>`도 마찬가지다.

```csharp
Array.Sort(arr);
Array.Reverse(arr);  // 5,4,3,2,1
```

> 이처럼 다양한 정렬 방법을 알아두는 것이 중요하다.

---

## 다중 조건 정렬 익히기

정렬 조건이 여러 개 필요할 때가 있다. (SQLD 공부할 때 정렬 조건 여러 개 줬던 것과 같은 개념.)

파이썬은 튜플 기반 정렬과 딕셔너리 기반 정렬이 있다 — 데이터를 튜플로 구성한 뒤 정렬 메서드를 쓰는 방식이다. C#은 `OrderBy()`에 `ThenBy()`를 체인으로 연결하는 방식을 쓴다.

```csharp
(int, int)[] Score = new[]
{
    (30, 40), // 국어, 수학 점수라고 치자
    (50, 60),
    (70, 80)
};

var sorted = Score
    .OrderBy(x => x.Item1)   // 1순위: 국어 점수 오름차순
    .ThenBy(x => x.Item2);   // 2순위: 수학 점수 오름차순
```

가독성 좋게 조건을 줄 수 있다.

**딕셔너리도 방식은 동일 — `KeyValuePair`를 기준으로**

```csharp
Dictionary<string, int> scores = new Dictionary<string, int>
{
    { "철수", 85 }, { "영희", 90 }, { "민수", 85 }
};

var sortedScores = scores
    .OrderBy(kvp => kvp.Value)   // 1순위: 점수 오름차순
    .ThenBy(kvp => kvp.Key);     // 2순위: 이름 오름차순
```

> 이게 C#에서 다중 조건 정렬의 가장 일반적인 방법이다.

---

## 이차원 리스트 다루기

코딩테스트에는 2차원 배열도 꼭 알아야 한다. 선언, 저장, 활용 방법을 알아야 문제를 풀 수 있다. (챕터 10에서 이미 다뤘으니 간단히 정리만.)

**선언법**

```csharp
int[,] grid = new int[N, M];  // N행 M열
```

**초기화**

```csharp
// 크기만 정하고 나중에 채우기
int[,] grid = new int[3, 3];

// 선언과 동시에 값 채우기
int[,] grid2 = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};
```

**접근법**

```csharp
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

**참고 — `int[,]` vs `int[][]`**

| | 다차원 배열 `int[,]` | 가변 배열 `int[][]` |
|--|----------------------|----------------------|
| 특징 | 모든 행의 열 수가 같음 | 행마다 열 수가 달라도 됨 |
| 접근 | `grid[i, j]` | `jagged[i][j]` |
| 코테 활용 | 격자(그리드) 문제 | 줄마다 입력 개수가 다른 경우 |

```csharp
// 입력이 줄마다 개수가 다를 때
int n = int.Parse(Console.ReadLine());
int[][] data = new int[n][];

for (int i = 0; i < n; i++)
{
    data[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
}
```
