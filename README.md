<div align="center">
<img src="https://github.com/user-attachments/assets/3f546352-b5c7-4f97-af06-1d2d7bb7b02a"/>
</div>
<p align="center">
  <img src="https://img.shields.io/badge/Language-C%23-Orange"/>
  <img src="https://img.shields.io/badge/Last%20Commit-April%202025-Orange">
</p>

# *Software Construction UG409765*

## Multiple Alarm Clock - Assessment 2

### Description
This repository is **Assessment 2** of the module **UG409765 - Software Construction** of the **BSc Computing** program at the **University of the Highlands and Islands (UHI)**. It serves as the foundation for the multi-alarm clock application, written in C#. The implementation of the analogue alarm clock Windows Form Application consists of a Sorted Array Priority Queue data structure to store alarms along with the alarm and clock logic constructed following the **Model-View-Presenter (MVP)** architecture. Including Nunit tests for each of the logic layers. The alarm View serves as the driver program to allow users to interact with the Priority Queue and create and dispose of alarms.


<br>
<br>
<div align="center">
<img src="https://github.com/user-attachments/assets/9dad2c5d-ad1d-47b4-9cc4-e123d0dcc5c6"/>
</div>


---

### Table of Contents
1. [Description](#description)
2. [Repository Structure](#repository-structure)
3. [Installation](#installation)
4. [Collaboration](#collaboration)
5. [License](#license)
6. [Contact](#contact)

---

# Repository Structure
The solution consists of Four projects: ClockV2, ClockV2.Tests, PriorityQueue and PriorityQueue.Tests

---
`Project` `ClockV2`
- `Alarm.cs`: A class used to represent an alarm with a name, time in seconds and timer. 
- `ClockDrawingHelper.cs`: A class to render the clockface and arms of the clock with each passing second.
- `IView.cs`: An interface that defines the contract for the AlarmView. 
- `AlarmModel.cs`: The Model Contains the business logic and manages the Sorted Array Priority Queue. Performs calculations or operations and returns the result back to the Alarm Presenter.   
- `ClockModel.cs`: The Model Performs calculations or operations and returns the result back to the Clock Presenter. In this instance it manages returning the current DateTime.   
- `AlarmPresenter.cs`: The Presenter acts as the intermediary between the Alarm Model and Alarm View. The View sends data to the Presenter where the Presenter then performs validation before passing to the Alarm Model and then passing back to the Alarm View. In this instance it also passes data to the Clock Presenter to be passed to the Clock View and displayed on the clock UI.   
- `ClockPresenter.cs`: The Presenter contains the business logic for updating and controlling the analogue clock. It acts as the intermediary between the Clock Model and Clock View. The Presenter sends data to the Clock View from the Clock Model and the Alarm Presenter to update the Clock View UI. 

- `AlarmView.cs`: The View acts as the user interface to create new alarms and to manage existing alarms. 
- `ClockView.cs`: The View acts as a graphical user interface that displays an analogue clockface thats hour minute and second hands are updated each tick at one second intervals. 
- `Program.cs`: The entry point for the ClockV2 application that launches the ClockView.


`Project` `ClockV2.Tests`
- `Alarm.Tests.cs`: Nunit testing for the Alarm Class.
- `AlarmModel.Tests.cs`: Nunit testing for the Alarm Model.
- `ClockModel.Tests.cs`: Nunit testing for the Clock Model.
- `AlarmPresenter.Tests.cs`: Nunit testing for the Alarm Presenter.
- `ClockPresenter.Tests.cs`: Nunit testing for the Clock Presenter.
- `AlarmView.Tests.cs`: Nunit testing for the Alarm View.
- `ClockView.Tests.cs`: Nunit testing for the Clock View.


`Project` `PriorityQueue` 
- `Node.cs`: A class used to represent an element in the Linked List Priority Queue data structures. It contains the Item (Person), Priority and Next pointer to the node. 
- `Person.cs`: A class used as a type for testing priority queues with the provided driver program.
- `PriorityItem.cs`: A class representing individual items within the priority queue. It includes properties for the item and its priority.
- `PriorityQueue.cs`: An interface defining the required methods for all Priority Queue implementations. This interface must not be modified.
- `QueueManager.cs`: A driver program implemented as a Windows Form application. It allows users to interact with and test different Priority Queue implementations.
- `QueueOverflowException.cs`:  A custom exception class for handling scenarios where the queue exceeds its defined capacity.
- `QueueUnderflowException.cs`: A custom exception class for handling scenarios where an operation is attempted on an empty queue.
- `SortedArrayPriorityQueue.cs`: A complete implementation of the Priority Queue using a sorted array. Highest priority is always at the head of the queue.
- `SortedLinkedPriorityQueue.cs`: A complete implementation of the Priority Queue using a linked list that is sorted according to priority. Highest priority is always at the head of the queue. 
- `UnsortedArrayPriorityQueue.cs`: A complete implementation of the Priority Queue using an unsorted array. 
- `UnsortedLinkedPriorityQueue.cs`: A complete implementation of the Priority Queue using a linked list that is unsorted.  


`Project` `PriorityQueue.Tests`
- `QueueManager.Tests.cs`: Nunit testing for the QueueManager user interface.
- `SortedArrayPriorityQueue.Tests.cs`: Nunit testing for the sorted array priority queue implementation.
- `SortedLinkedPriorityQueue.Tests.cs`: Nunit testing for the sorted linked list priority queue implementation.
- `UnsortedArrayPriorityQueue.Tests.cs`: Nunit testing for the unsorted array priority queue implementation.
- `UnsortedLinkedPriorityQueue.Tests.cs`: Nunit testing for the unsorted linked list priority queue implementation.

---

# Installation
Following the steps below should install all dependencies referenced inside the PriorityQueue.csproj file for the entire project including Nunit and its dependencies for testing.

---

1. Check If Git is installed
```bash
git --version
```

2. Check if .NET is installed
```bash
dotnet --version
```

3. Navigate to Project directory
```bash
cd path\to\project
```

4. Clone Repo
```bash
gh repo clone A-Macleod/PriorityQueue
```

5. Install Dependencies 
```bash
dotnet restore
```

6. Build Project
```bash
dotnet build
```

7. Run Project
```bash
dotnet run
```

---

# Collaboration 
I am currently not looking for collaborators on this project

# License
UHI

# Contact
For any issues or questions, please reach out to 0308180@uhi.ac.uk

