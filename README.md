# TowerDefenseGame2.0
```mermaid
flowchart TD
    A[Start Level] -->|GameObject Hero spawn| B(Hero position)
    B --> C{mouse position}
    C -->|Search mouse position| D[If found]
    D --> E(Hero move to mouse position)
    E --> F(Enemies in Hero range)
    F --> |If enemies are in range| H(Attack enemies)
    F --> |If enemies are not in range| G( Do nothing)
 
