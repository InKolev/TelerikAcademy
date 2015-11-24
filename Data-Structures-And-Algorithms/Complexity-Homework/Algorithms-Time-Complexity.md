

Data Structures, Algorithms and Complexity Homework
---------------------------------------------------
Tasks
----------


**Task - 1**
![enter image description here](http://s9.postimg.org/71olqa8un/Task_1.jpg)

**Task - 2**
![enter image description here](http://s22.postimg.org/srrbd2oc1/Task_2.jpg)

**Task - 3**
![enter image description here](http://s15.postimg.org/qfqr6phyj/Task_3.jpg)

Solutions
---------

----------


1. Solution: (1 + n(n+2n + 1)) = 1 + n^2 + (2n)^2 + n = (3n)^2 + n + 1 = O(n^2)
2. Solution: (1 + n(n(m(m + 1)) = 1 + (n^2(m^2 + m)) = 1 + (m^2)(n^2) + m(n^2) = O(m*n)
3. Solution: (1 + m(1 + n) = (1 + m + m.n) = O(m.n)

**Explanation for Task-3:** We have a recursive algorithm. For each row in the matrix - the function calls itself with an incremented rows count as a parameter until the **rows count** are equal to **max(rows count)** for the matrix . 

If we assume **m** and **n** are large enough numbers, we can ignore the constants (2 in our case) and focus on the most difficult part of our equation (in terms of time complexity/CPU instructions count).

Lets assume we have  ( **m = 100 000** ) and ( **n = 1 000 000** ). In this case (m.n) takes **999 999 more time** to calculate than (**m**), so we can ignore this (**m**) part of the equation. Now all we have left is the largest member of our equation so this is our algorithm's time complexity -> **O(m.n)**

We use the same approach when calculating the time complexity for the above two algorithms. 
**Extract equation** --> **Ignore the insignificant parts** --> **Take the part which takes the most amount of time to calculate** --> **This is your time complexity described in BIG-O notation (a.k.a asymptotic notation).** 