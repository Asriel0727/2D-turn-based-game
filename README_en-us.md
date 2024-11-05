# 2D Game Development - [Mars Mutation](asriel0727.github.io/2D-turn-based-game/)

<div align="center">

| [繁體中文](README.md) | [English](README_en-us.md) |  [PDF Documentation](Doc/遊戲發想提案(GDD).pdf) |

</div>

## Project Overview
1. **Game Content**
   - Single-player, third-person 2D turn-based game
   - Players start with a basic weapon (knife)
   - Enter levels based on the storyline, complete objectives to receive rewards
   - Collect equipment to enhance character abilities
   - Buy/sell weapons in the shop

2. **Game Story**  
   In the near future, scientists discover a new Mars-like planet, though it is initially uninhabitable for humans. To determine its suitability for human survival, scientists first conduct environmental tests on animals. However, even before the experiments are completed, adverse effects start to appear on Earth.

   Forced to leave Earth, humanity sends an initial crew to conduct species tests on this new planet. Unfortunately, the species do not survive and instead mutate. As part of the pioneer force, players must stand on the frontline, facing mutated creatures and fighting to survive.

   Throughout the storyline, players act as members of the pioneer team, confronting the unknown planetary environment and mutated monsters. Using their weapons and tactics, players must fight to survive, finding solutions in an unfamiliar setting and battling against strange creatures in a journey filled with unknowns and adventure.

3. **Target Audience**  
   The game features a retro pixel art style suitable for all ages, paired with a turn-based combat system to provide a satisfying battle experience. It is designed to be accessible and enjoyable without causing frustration, focusing on delivering fun, strategic combat.

   During battles, players will face various monsters and engage in turn-based combat. A unique "guard-breaking" mechanic is one of the game’s highlights, allowing players to use special skills or strategies to break through monster defenses, adding depth and challenge to each fight.

## Resources
- **Art Assets**
  - Pixiv
  - Pinterest
- **Music and Sound Effects**
  - [Taira Komori's Free Sound Effects](https://taira-komori.jpn.org/freesoundtw.html)
  - [Chinaz](https://sc.chinaz.com/yinxiao/)

## Collaboration Tools
- GitHub
- Canva

## Project Status
- **Current Issues**  
  - [ ] NPC dialogue in the web version’s shop does not display
        => Issue caused by storing data files in StreamingAssets, inaccessible in WebGL; will move to Resources directory
  - [ ] Initialization error on game start leads to direct Game Over screen

- **Future Plans**
  - [ ] Implement data-driven systems for shop content, player inventory, player data, and monster attributes for scalability.
  - [ ] Define statuses for players and monsters during combat.
  - [ ] Add subsequent levels.

- **Optimization List**
  - [ ] Data-driven values
  - [ ] Implement state machine for combat
