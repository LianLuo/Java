```flow
sta=>start: 开始
e=>end: 结束
op=>operation: 操作（处理块）
sub=>subroutine: 子程序
cond=>condition: 是或者不是（条件判断）?
cond2=>condition: 第二个判断（条件判断）?
io=>inputoutput: 输出

sta->op->cond
cond(yes)->e
cond(no)->cond2
cond2(yes,right)->sub(left)-op
cond2(no)->io(lef)->e
```

```mermaid
graph LR
    fa:fa-check-->fa:fa-coffee
```

```mermaid
sequenceDiagram
title : three sequence
participant 小王
participant 小李
participant 小异常
note left of 小王:我是小王
note over 小李:我是小李
note right of 小异常:大家好！\n我是小异常
小王->小王:小王想:今天要去见两个好朋友~~
小王->小李:嘿，小李好久不见啊~~
小李-->小王:yes!
小李->小异常:小异常，你好！
小异常-->小王:哈，小王！\n最近身体怎么样了？
小王->>小异常:还可以吧
```

```mermaid
    graph LR
    A(module A)-->|A2|B2[Moduel 2]
    B --> C{condition C}
    C --> |condition c1| D1(Mdouel D)
    C --> |condition c2| E1(Module E)
    C --> |condition c3| F1(Module F)
```

```mermaid
graph TB
    id1(circle)--normal-->id2[rectagle]
    subgraph subgraph
        id2 ==bold==>id3{xxx}
        id3 -.fff.->id4>right flag]
        id3 --你好--- id5((fff))
    end
```

### class graph
```mermaid
classDiagram
Class01 <|-- AveryLongClass : Cool
Class03 *-- Class04
Class05 o-- Class06
Class07 .. Class08
Class09 --> C2 : Where am i?
Class09 --* C3
Class09 --|> Class07
Class07 : equals()
Class07 : Object[] elementData
Class01 : size()
Class01 : int chimp
Class01 : int gorilla
Class08 <--> C2: Cool label

```

### Git graph 
```mermaid
gitGraph:
options
{
    "nodeSpacing": 150,
    "nodeRadius": 10
}
end
    commit
    branch newbranch
    checkout newbranch
    commit
    commit
    checkout master
    commit
    commit
    merge newbranch
```

### Gantt Diagram

#### Sytax
```javascript
gantt
       dateFormat  YYYY-MM-DD
       title Adding GANTT diagram functionality to mermaid

       section A section
       Completed task            :done,    des1, 2014-01-06,2014-01-08
       Active task               :active,  des2, 2014-01-09, 3d
       Future task               :         des3, after des2, 5d
       Future task2              :         des4, after des3, 5d

       section Critical tasks
       Completed task in the critical line :crit, done, 2014-01-06,24h
       Implement parser and jison          :crit, done, after des1, 2d
       Create tests for parser             :crit, active, 3d
       Future task in critical line        :crit, 5d
       Create tests for renderer           :2d
       Add to mermaid                      :1d

       section Documentation
       Describe gantt syntax               :active, a1, after des1, 3d
       Add gantt diagram to demo page      :after a1  , 20h
       Add another diagram to demo page    :doc1, after a1  , 48h

       section Last section
       Describe gantt syntax               :after doc1, 3d
       Add gantt diagram to demo page      :20h
       Add another diagram to demo page    :48h
```
#### Example
```mermaid
gantt
dateFormat  YYYY-MM-DD
title Adding GANTT diagram to mermaid
excludes weekdays 2014-01-10

section A section
Completed task            :done,    des1, 2014-01-06,2014-01-08
Active task               :active,  des2, 2014-01-09, 3d
Future task               :         des3, after des2, 5d
Future task2               :         des4, after des3, 5d
```

### Sequence Diagram
```mermaid
sequenceDiagram
    participant Alice
    participant Bob
    Alice->>John: Hello John, how are you?
    loop Healthcheck
        John->>John: Fight against hypochondria
    end
    Note right of John: Rational thoughts <br/>prevail!
    John-->>Alice: Great!
    John->>Bob: How about you?
    Bob-->>John: Jolly good!
```

### Flowchart
```mermaid
graph TD;
    A-->B;
    A-->C;
    B-->D;
    C-->D;
```

### State Diagrams
```mermaid
stateDiagram
    [*] --> Still
    Still --> [*]

    Still --> Moving
    Moving --> Still
    Moving --> Crash
    Crash --> [*]
```

```mermaid
stateDiagram
    [*] --> First
    state First {
        [*] --> second
        second --> [*]
    }
```

```mermaid
stateDiagram
    [*] --> First

    state First {
        [*] --> Second

        state Second {
            [*] --> second
            second --> Third

            state Third {
                [*] --> third
                third --> [*]
            }
        }
    }
```

```mermaid
stateDiagram
    [*] --> First
    First --> Second
    First --> Third

    state First {
        [*] --> fir
        fir --> [*]
    }
    state Second {
        [*] --> sec
        sec --> [*]
    }
    state Third {
        [*] --> thi
        thi --> [*]
    }
```

### Pie chart diagrams
```mermaid
pie title Pets adopted by volunteers
    "Dogs" : 386
    "Cats" : 85
    "Rats" : 15 
```

```mermaid
pie
    title Key elements in Product X
    "Calcium" : 42.96
    "Potassium" : 50.05
    "Magnesium" : 10.01
    "Iron" :  5
```
#### Syntax
```javascript
[pie] [title] [titlevalue] (OPTIONAL)
"[datakey1]" : [dataValue1]
"[datakey2]" : [dataValue2]
"[datakey3]" : [dataValue3]
```

#### Example
```mermaid
pie
    title Key elements in Product X
    "Calcium" : 42.96
    "Potassium" : 50.05
    "Magnesium" : 10.01
    "Iron" :  5
```