# 🧠 Tactical Grid Prototype

This project is a **prototyping ground** for a turn-based, grid-based tactics game, inspired by systems like _XCOM_, _Tacticus_, and _D&D_. The focus is on **clean architecture**, **scalability**, and **AI behavior** that can adapt over time.

---
## 📹 Preview

![Grid Prototype](./grid_prototype_preview.gif)

## ✅ Current Features

- Grid-based movement system using a `GridTile` pool
- Turn-based controller with queueing and coroutine execution
- MVC architecture with SOLID principles and dependency injection (via Zenject)
- Player and Enemy units using shared interfaces
- Pathfinding using **BFS** (not A*, see below)
- Smooth movement animations with custom curves
- Separated AI logic that returns intent, which the controller executes
- Mock data providers for controlled unit testing and iteration

---

## 🚫 Why We're Not Using A* (Yet)

Although **A\*** is the industry standard for tactical pathfinding, this prototype currently uses **BFS** because:

- The grid has **no obstacles** or **terrain weights**
- Movement range is limited and consistent
- BFS is extremely fast and simpler for this phase
- Future extensions (A*, Dijkstra, Dijkstra maps) are planned once:
  - Cover zones are added
  - Flanking mechanics are introduced
  - Tactical weights or hazard zones exist

---

## 📹 Preview

https://user-images.githubusercontent.com/.../Screen%20Recording%202025-04-14%20at%2012.10.47.mov

*Above: Enemy moves toward player using range-limited BFS, with smooth LERP movement.*

> Let me know if you'd like me to host the video or embed it via YouTube or GitHub-compatible format.

---

## 🧠 Future Plan: Adaptive AI

We're laying the groundwork for an **enemy AI that learns from player behavior**, including:

- Tracking player tendencies:
  - Hiding
  - Rushing
  - Flanking
- Adjusting AI tactics dynamically:
  - Increasing aggression if player hides
  - Falling back or spreading out if player rushes
- Visual indicators of AI adaptation

This will evolve into a modular `IEnemyAI` system where each difficulty level (normal, hard, adaptive) can be swapped or blended in runtime.

---

## 💡 Technologies & Design Principles

- **Unity** 2022+
- **Zenject** for dependency injection
- **MVC + SOLID**
- **ScriptableObjects** for data (planned)
- **Object Pooling** for grid and unit visuals
- **Unit-testable** service layers

---

## 📌 Disclaimer

This is an early **prototype** meant to validate architecture and systems. Visuals and final game rules are in progress. Contributions are welcome once the core loop stabilizes.

