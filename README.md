# AI-Enemy

# 🧪 Tactical Game Prototype – Unity Architecture

This project is an early **prototype** of a turn-based tactical game inspired by systems found in games like *XCOM*, *Tacticus*, and *D&D*. The goal is to set up a **scalable, testable architecture** with core gameplay elements in place.

> ⚠️ This is not a polished game. It is a **work-in-progress foundation** for further development.

---

## 🎯 Goals

- ✅ Rapidly prototype turn-based gameplay
- ✅ Build a clean architecture from the start
- ✅ Follow best practices (SOLID, MVC, DI)
- ✅ Ensure scalability for new systems (AI, abilities, etc.)

---

## 🧱 Architectural Principles

### ✅ **MVC Pattern**
- **Model** – Data and logic (e.g., PlayerData, TurnOrder)
- **View** – MonoBehaviours that handle rendering and input (e.g., PlayerView, GridTileView)
- **Controller** – Coordinates models and views, and contains main logic (e.g., TurnController, EnemyController)

### ✅ **SOLID Principles**
- **Single Responsibility** – Each class does one thing 
- **Open/Closed** – New AI types or pathfinding strategies can be added without modifying existing code
- **Liskov, Interface Segregation, Dependency Inversion** – Encouraged through proper interface design and Zenject

### ✅ **Dependency Injection (DI)**
- Using [**Zenject**](https://github.com/modesttree/Zenject) for all system-wide injection
- Reduces coupling and simplifies testing/replacement of systems (e.g., `IEnemyAI`, `IPathfinder`)

### ✅ **Modularity**
- All systems are built in isolation and interact through interfaces
- Example: `TurnSystem`, `Pathfinding`, and `GridAgents` are completely swappable

---

## 🔁 Systems in Place

- ✅ **Grid System** (generated with object pooling)
- ✅ **Turn System** (queue-based and coroutine-driven)
- ✅ **Enemy + Player Agents** (following `IGridAgentController`)
- ✅ **A\* Pathfinding** (clean and testable, SOLID-compliant)
- ✅ **Basic AI Abstraction** (`IEnemyAI` with room for easy extension)

---

## 🧪 Testing & Extensibility

- Interfaces are designed for **unit testing** and mocking
- Use Zenject test contexts to isolate systems in editor or runtime tests
- Plug-and-play architecture for:
    - Enemy difficulty levels
    - Different movement systems
    - New pathfinding strategies (e.g. Dijkstra, BFS)

---

## 🛠️ Next Steps

- [ ] Add player input logic (UI or click-to-move)
- [ ] Implement health, attack,range and damage resolution
- [ ] Build adaptive AI with pattern tracking
- [ ] Add unit tests for grid & pathfinding
- [ ] Change systems to resolve prefabs through centralized prefab system
- [ ] Visual implementation - VFX, Assets optimization, prefabs optimization
- [ ] Networking
- [ ] Reading data from cloud/scriptable object (grid size, health etch)

---

## 🧠 Why This Approach?
This project is not just about mechanics — it’s a testbed for:

- Clean game architecture
- Reusable systems
- Rapid prototyping in teams or solo
- Teaching / sharing scalable game code

---

## 🧃 Tools Used

- **Unity** (URP)
- **Zenject** – Dependency injection
- **Custom A\*** – Pathfinding
- **C#** – SOLID & clean architecture principles

---

