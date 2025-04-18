
# 🔁 Page Replacement Algorithms Simulator (FIFO, LRU, Optimal)

## 📌 Overview

This project is a Unity-based simulation of **three classic page replacement algorithms**:
- FIFO (First-In, First-Out)
- LRU (Least Recently Used)
- OPT (Optimal)

It was developed as part of an asynchronous final activity for April 11, 2025, in accordance with the instructions from the CCS course's Chapter 10 (Virtual Memory Management).

---

## 🎯 Objectives

- Simulate **FIFO**, **LRU**, and **Optimal** page replacement algorithms.
- Use a **randomly generated page reference string** (pages 0–9).
- Accept a **custom number of page frames** at runtime.
- Track and display the **number of page faults** for each algorithm.
- Show **step-by-step GUI representations** for each algorithm.
- Provide **screen captures** and documentation for evaluation.

---

## 🧠 Algorithms Implemented

### ✅ FIFO (First-In, First-Out)
Replaces the oldest page in memory.

### ✅ LRU (Least Recently Used)
Replaces the page that has not been used for the longest time.

### ✅ OPT (Optimal)
Replaces the page that will not be used for the longest time in the future.

---

## 💻 Technologies Used

- Unity (C#)
- TextMeshPro for UI
- Visual Studio Code / Unity Editor

---

## 🗂️ Repository Contents

```
📁 Assets/
├── Scripts/
│   ├── FIFOAlgorithm.cs
│   ├── LRUAlgorithm.cs
│   ├── OptimalAlgorithm.cs
│   └── DataManager.cs
├── Prefabs/
│   ├── FrameSlot.prefab
│   └── FaultText.prefab
├── Scenes/
│   └── MainScene.unity
📄 PageReplacementDocumentation.pdf
📄 PageReplacementExecutable.exe
📄 README.md
```

---

## 📸 Sample Screenshots

The documentation includes **screen captures of three sample inputs and outputs** for each algorithm, showcasing how the system responds to different random reference strings and frame counts.

---

## 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/PageReplacementSimulator.git
   ```

2. Open the project in **Unity Hub**.

3. Load the `MainScene.unity`.

4. Enter the number of frames and click **Generate** to simulate.

5. Use the respective buttons to simulate:
   - FIFO
   - LRU
   - OPT

6. View GUI rendering and fault count per algorithm.

---

## 📄 Submission Requirements

✔️ Source Code (with detailed comments)  
✔️ Executable File (.exe from Unity build)  
✔️ Documentation File (PDF/Word with screenshots)  
✔️ GitHub Repository Link ✅

---

## 🧑‍🎓 Author

**Marc Jersey M. Castro**  
BSCS / CCS Student  
Final Project – Chapter 10: Page Replacement Algorithms  
April 11, 2025  

---

## 📝 License

This project is for academic purposes only.

---