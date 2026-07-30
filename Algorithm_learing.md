# Algorithms Learning Notes

## 1. Big-O Notation (Time & Space Complexity)

Code কতটা efficient, তা measure করার ভাষা। এটি প্রধানত দুইটি দিককে বোঝায়:

- Time Complexity: code কত দ্রুত চলে
- Space Complexity: memory কতখানি ব্যবহার করে

| Notation | অর্থ | উদাহরণ |
|---|---|---|
| O(1) | Constant | Array index access |
| O(n) | Linear | Array-এ maximum খোঁজা |
| O(n²) | Quadratic | Nested loop দিয়ে duplicate খোঁজা |
| O(log n) | Logarithmic | Binary search |

> গুরুত্বপূর্ণ কথা: Time আর Space complexity সবসময় আলাদা করে হিসাব করতে হবে। একটাকে আরেকটার সাথে গুলিয়ে ফেললে ভুল হবে।

## 2. Array

- Memory-এ contiguous (পাশাপাশি)ভাবে хран করা হয়
- Index access = O(1)
- Beginning বা middle-এ insert/delete = O(n), কারণ বাকি সব element shift করতে হয়

## 3. Dynamic Array

C#-এর `List<T>` এবং Go-এর `slice`-এর মতো structure।

- ভিতরে একটি fixed array রাখা হয়
- Capacity (মোট জায়গা) এবং Length (আসল data) আলাদাভাবে track করা হয়
- জায়গা ফুরিয়ে গেলে নতুন বড় array তৈরি করে পুরনো data copy করা হয়
- এজন্য `Add/Append` সাধারণত amortized O(1), কিন্তু মাঝে মাঝে resize হওয়ার সময় O(n) হতে পারে

### Optimization

যদি আগে থেকেই size জানা থাকে, তবে `new List<int>(1000)`-এর মতো করে capacity reserve করলে বারবার copy এবং GC overhead কমানো যায়।

## 4. Linked List

- Node-based structure
- Memory-এ ছড়িয়ে ছিটিয়ে থাকতে পারে
- প্রতিটি node পরের node-এর address (pointer) রাখে

### Complexity

- Beginning-এ insert/delete = O(1)
- Index/position access = O(n)

### Advantage / Disadvantage

- Advantage: insert/delete দ্রুত
- Disadvantage: memory overhead বেশি এবং cache-unfriendly

## 5. Array vs Linked List

| Needs | Best Choice |
|---|---|
| ঘন ঘন random access/read | Array |
| ঘন ঘন insert/delete (বিশেষত শুরুতে) | Linked List |

## 6. Stack (LIFO) vs Queue (FIFO)

- Stack: সর্বশেষে ঢোকা element আগে বের হয় (`Push/Pop`)
- Queue: প্রথমে ঢোকা element আগে বের হয় (`Enqueue/Dequeue`)

### Examples

- Stack: function call stack, undo feature
- Queue: order management, task scheduling, BFS

দুইটির মূল operation-ই O(1)।

## 7. Hash Map / Hash Set

- Key-কে hash function দিয়ে index-এ convert করা হয়
- তারপর array access করে lookup করা হয়
- এজন্য lookup average O(1)

### Collision

দুইটি key একই index পেলে collision ঘটে। Common solution হলো chaining, যেখানে একই index-এ Linked List রাখা হয়।

### Important Idea

- Duplicate detection-এ O(n²) থেকে O(n) এ আনা যায়
- এটি Time-Space trade-off-এর একটি ভালো উদাহরণ

## 8. Data Structure Summary

| Data Structure | Main Strength | Main Weakness |
|---|---|---|
| Array | O(1) access | O(n) insert/delete |
| Linked List | O(1) insert/delete (শুরুতে) | O(n) access |
| Stack | O(1) LIFO push/pop | শুধুমাত্র এক প্রান্তে কাজ করে |
| Queue | O(1) FIFO enqueue/dequeue | শুধুমাত্র এক প্রান্তে কাজ করে |
| Hash Map | O(1) lookup | Collision handle করা লাগে, memory বেশি |
| Tree (BST) | O(log n) search (balanced হলে) | Unbalanced হলে O(n) |
| Heap | O(1) min/max | O(log n) insert/delete |
| Graph | Real-world network model করা যায় | Traversal/algorithm complex |

## 9. Tree, Heap, and Graph

### Tree (Binary Search Tree)

- Hierarchical structure
- Root থেকে শুরু, parent-child relationship থাকে
- Leaf node-এর নিচে আর child থাকে না

#### Binary Tree

- প্রতিটি node-এর সর্বোচ্চ ২টি child থাকতে পারে: Left এবং Right

#### BST Rule

- Left subtree-এ সব value ছোট
- Right subtree-এ সব value বড়

#### Complexity

- Search = O(log n) (balanced হলে)
- Sorted data insert করলে tree skewed হয়ে যেতে পারে, ফলে search O(n) এ নেমে যেতে পারে

#### Solution

- AVL Tree বা Red-Black Tree ব্যবহার করে self-balancing 유지 করা যায়

#### Traversal Types

| Type | Order | Use |
|---|---|---|
| In-Order | Left → Node → Right | Sorted output |
| Pre-Order | Node → Left → Right | Tree copy বানানো |
| Post-Order | Left → Right → Node | Tree delete করা |

সব traversal-ই O(n)।

### Heap

- এটি একটি binary tree, কিন্তু BST-এর মতো ordering rule নেই
- Parent সবসময় child-এর চেয়ে ছোট (Min-Heap) বা বড় (Max-Heap)

#### Complexity

- Min/Max extract = O(1)
- Insert/Delete = O(log n)

#### Use Cases

- Priority Queue
- Task scheduling
- Dijkstra's shortest path
- Top-K elements বের করা

C#-এ built-in support হিসেবে `PriorityQueue<T, TPriority>` ব্যবহার করা যায়।

### Graph

- সবচেয়ে general structure
- যেকোনো node যেকোনো node-এর সাথে connect হতে পারে
- cycle থাকতে পারে

#### Main Terms

- Vertex (node)
- Edge (connection)

#### Directed vs Undirected

- Directed: এক দিকে connection
- Undirected: দুই দিকে connection

#### Representation

| Method | Memory | Connection Check | Best For |
|---|---|---|---|
| Adjacency List | O(V + E) | O(V) worst case | Sparse graph |
| Adjacency Matrix | O(V²) | O(1) | Dense graph |

#### Traversal

- BFS: Queue ব্যবহার করে level-by-level visit করে
- DFS: Stack/recursion ব্যবহার করে গভীরে গিয়ে তারপর ফিরে আসে
