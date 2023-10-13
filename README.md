# Molly Rocket Video Benchmark Analysis
This repository was created to investigate the claims made by Molly Rocket, a prominent figure in the industry, in his video titled Video Title(https://www.youtube.com/watch?v=tD5NrevFtbU&t=654s&ab_channel=MollyRocket).
In the video, Molly Rocket discusses certain performance-related aspects, and this project uses benchmarking techniques and C# to validate or challenge those claims.


Background
Molly Rocket claims that polymorphism performance is much worse than switch case or table-driven case.
Replication of Molly Rocket's Logic
It's important to note that the code used in this project closely replicates the logic presented by Molly Rocket in his video.
The goal was to create scenarios as close as possible to his to ensure a fair and accurate benchmark analysis.

Features
List the key features or functionalities of your benchmarking project:
BenchmarkDotNet V 0.13.8 tool for measuring performance.

# Results
* The claim that switch case performance is better than polymorphism is incorrect. In both parts of the video, the benchmark results indicate that polymorphism performs better than switch cases.
* The claim about the table-driven case is correct. The benchmark results show that the table-driven case consistently performs much better than both switch case and polymorphism in both parts of the video.

* First Part Benchmark:
![image](https://github.com/TimaKuDev/CleanCodeBenchMark/assets/53705199/9161dedb-9924-4efc-9774-4fa17a367a36)
* Second Part BenchMark:
![image](https://github.com/TimaKuDev/CleanCodeBenchMark/assets/53705199/eada4cb6-45d8-4f3b-bbf6-e26da52ed4ff)
* First Part Best Case Scenario:
![image](https://github.com/TimaKuDev/CleanCodeBenchMark/assets/53705199/03721a31-8217-46a5-831c-d4ece26010df)
* First Part Worst Case Scenario:
![image](https://github.com/TimaKuDev/CleanCodeBenchMark/assets/53705199/a7cea882-1eee-415d-b9be-ae4ca858791c)
* Second Part Best Case Scenario:
![image](https://github.com/TimaKuDev/CleanCodeBenchMark/assets/53705199/81908813-3cad-46b0-905e-a146842c5332)
* Second Part Worst Case Scenario:
![image](https://github.com/TimaKuDev/CleanCodeBenchMark/assets/53705199/631747e9-9679-4ce7-abc1-fe1ab41abf2b)


# Benchmarking Details

For each test, a set of shapes was created with different parameters to simulate a realistic scenario.
These shapes were then inserted into an array.
The benchmarking tool was used to measure the execution time of various methods for calculating the area of these shapes.
The goal was to determine the fastest method for area calculation, similar to what Molly Rocket demonstrated in his video.
The benchmarking process was repeated for different shape amounts, including 10, 100, 1000, 10000, and 100000, to assess performance scalability.
Molly Rocket's Claims

This project is licensed under the MIT License.
