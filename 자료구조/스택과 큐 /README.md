# 스택과 큐

> 스택과 큐는 자료구조다. (이미 알겠지만) 복습 차원에서 간단하게 보고 가자.

---

## 📚 목차

- 1. [스택 (Stack)](#1-스택-stack)
  - [1.1 문제: 스택으로 수열 만들기](#1-문제-스택으로-수열-만들기)
- 2. [큐 (Queue)](#2-큐-queue)
- 3. [코딩테스트 활용 유형](#3-코딩테스트-활용-유형)

---

## 1. 스택 (Stack)

블록을 쌓듯이 데이터를 저장하는 자료구조. **후입선출(LIFO, Last In First Out)** 이 핵심 특징이다. 가장 마지막에 들어온 데이터가 가장 먼저 빠져나간다.

```csharp
Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

Console.WriteLine(stack.Pop());  // 3 (가장 나중에 넣은 게 먼저 나옴)
```
### 1.1 문제 스택으로 수열 만들기 


---

## 2. 큐 (Queue)

스택과 반대로 **선입선출(FIFO, First In First Out)**. 가장 먼저 들어온 데이터가 먼저 빠져나가고, 뒤에 들어온 데이터는 맨 뒤에 남아 있다.

```csharp
Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

Console.WriteLine(queue.Dequeue());  // 1 (가장 먼저 넣은 게 먼저 나옴)
```

---

## 3. 코딩테스트 활용 유형

**스택이 자주 쓰이는 문제 유형**
- 괄호 짝 맞추기 (여는 괄호를 넣고, 닫는 괄호 만나면 꺼내서 비교)
- 문자열 되돌리기, 실행 취소(Undo)
- DFS(깊이 우선 탐색) 구현

**큐가 자주 쓰이는 문제 유형**
- BFS(너비 우선 탐색) 구현
- 시뮬레이션 문제 (대기열, 순서대로 처리)

---
