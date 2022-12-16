using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alchemy
{
   static class AlchemyCombinations
   {
      private static AlchemyCombination[] combinations;

      static AlchemyCombinations()
      {
         combinations = new AlchemyCombination[]
         {
            // Water+Water=Ocean
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Water],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ocean],
            },
            // Earth+Earth=Pressure
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pressure],
            },
            // Fire+Earth=Lava
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lava],
            },
            // Lava+Earth=Volcano
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lava],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Volcano],
            },
            // Volcano+Pressure=Lava+Ash
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Volcano],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lava],
               Result2 = AlchemyElements.Elements[ElementIndexes.Ash],
            },
            // Lava+Air=Stone
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lava],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Stone],
            },
            // Stone+Fire=Metal
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Stone],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Metal],
            },
            // Air+Air=Wind
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Wind],
            },
            // Earth+Water=Swamp
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Swamp],
            },
            // Air+Fire=Energy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Energy],
            },
            // Energy+Ocean=Life
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Energy],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ocean],
               Result1 = AlchemyElements.Elements[ElementIndexes.Life],
            },
            // Life+Ocean=Algae
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Life],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ocean],
               Result1 = AlchemyElements.Elements[ElementIndexes.Algae],
            },
            // Life+Swamp=Bacteria
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Life],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Swamp],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bacteria],
            },
            // Bacteria+Swamp=Worm+Sulfur
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bacteria],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Swamp],
               Result1 = AlchemyElements.Elements[ElementIndexes.Worm],
               Result2 = AlchemyElements.Elements[ElementIndexes.Sulfur],
            },
            // Life+Ash=Ghost
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Life],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ash],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ghost],
            },
            // Fire+Water=Steam
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Steam],
            },
            // Stone+Water=Sand
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Stone],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sand],
            },
            // Air+Stone=Sand
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Stone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sand],
            },
            // Air+Earth=Dust
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dust],
            },
            // Dust+Dust=Ash+Ash
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dust],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Dust],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ash],
               Result2 = AlchemyElements.Elements[ElementIndexes.Ash],
            },
            // Ash+Ash=Dust+Dust
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ash],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ash],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dust],
               Result2 = AlchemyElements.Elements[ElementIndexes.Dust],
            },
            // Dust+Fire=Gunpowder
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dust],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Gunpowder],
            },
            // Dust+Water=Mud
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dust],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mud],
            },
            // Dust+Life=Mite
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dust],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mite],
            },
            // Dust+Earth=Dust
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dust],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dust],
            },
            // Life+Sand=Seed
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Life],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sand],
               Result1 = AlchemyElements.Elements[ElementIndexes.Seed],
            },
            // Sand+Swamp=Clay
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sand],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Swamp],
               Result1 = AlchemyElements.Elements[ElementIndexes.Clay],
            },
            // Sand+Fire=Glass
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sand],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Glass],
            },
            // Sand+Worm=Snake
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sand],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Worm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Snake],
            },
            // Sand+Water=Beach
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sand],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Beach],
            },
            // Sand+Ocean=Beach
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sand],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ocean],
               Result1 = AlchemyElements.Elements[ElementIndexes.Beach],
            },
            // Sand+Sand=Desert
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sand],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sand],
               Result1 = AlchemyElements.Elements[ElementIndexes.Desert],
            },
            // Pressure+Sand=Silicon
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pressure],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sand],
               Result1 = AlchemyElements.Elements[ElementIndexes.Silicon],
            },
            // Sand+Glass=Hourglass
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sand],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Glass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hourglass],
            },
            // Mud+Life=Bacteria
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mud],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bacteria],
            },
            // Seed+Earth=Tree
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Seed],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tree],
            },
            // Life+Stone=Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Life],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Stone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Egg+Swamp=Lizard
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Egg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Swamp],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lizard],
            },
            // Lizard+Earth=Beast
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lizard],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Beast],
            },
            // Beast+Tree=Monkey
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Monkey],
            },
            // Monkey+Earth=Man
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Monkey],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Man],
            },
            // Beast+Life=Man
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Man],
            },
            // Tree+Tree=Grove
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tree],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Grove],
            },
            // Grove+Grove=Forest
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Grove],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Grove],
               Result1 = AlchemyElements.Elements[ElementIndexes.Forest],
            },
            // Man+Metal=Tool
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tool],
            },
            // Beast+Man=Livestock+Man
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Livestock],
               Result2 = AlchemyElements.Elements[ElementIndexes.Man],
            },
            // Beast+Forest=Bear
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Forest],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bear],
            },
            // Bear+Tree=Panda
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bear],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Panda],
            },
            // Beast+Water=Shark
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Shark],
            },
            // Air+Egg=Bird
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Egg],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bird],
            },
            // Egg+Fire=Omelette
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Egg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Omelette],
            },
            // Egg+Sand=Turtle
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Egg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sand],
               Result1 = AlchemyElements.Elements[ElementIndexes.Turtle],
            },
            // Turtle+Desert=Tortoise
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Turtle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Desert],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tortoise],
            },
            // Bird+Bird=Bird+Bird+Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bird],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bird],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bird],
               Result2 = AlchemyElements.Elements[ElementIndexes.Bird],
               Result3 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Lizard+Lizard=Lizard+Lizard+Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lizard],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Lizard],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lizard],
               Result2 = AlchemyElements.Elements[ElementIndexes.Lizard],
               Result3 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Snake+Snake=Snake+Snake+Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Snake],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Snake],
               Result1 = AlchemyElements.Elements[ElementIndexes.Snake],
               Result2 = AlchemyElements.Elements[ElementIndexes.Snake],
               Result3 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Egg+Water=Fish
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Egg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fish],
            },
            // Fish+Egg=Caviar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fish],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Egg],
               Result1 = AlchemyElements.Elements[ElementIndexes.Caviar],
            },
            // Earth+Egg=Dinosaur
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Egg],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
            },
            // Dinosaur+Dinosaur=Dinosaur+Dinosaur+Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               Result2 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               Result3 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Egg+Life=Chicken
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Egg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Chicken],
            },
            // Silicon+Tool=Transistor
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Silicon],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Transistor],
            },
            // Transistor+Tool=Chip
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Transistor],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Chip],
            },
            // Chip+Tool=Computer
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Chip],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Computer],
            },
            // Transistor+Air=Radio
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Transistor],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Radio],
            },
            // Radio+Radio=Radar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Radio],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Radio],
               Result1 = AlchemyElements.Elements[ElementIndexes.Radar],
            },
            // Water+Glass=Ice
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Water],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Glass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ice],
            },
            // Ice+Bear=PolarBear
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ice],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bear],
               Result1 = AlchemyElements.Elements[ElementIndexes.PolarBear],
            },
            // Beast+Mud=Hippopotamus
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Mud],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hippopotamus],
            },
            // Wind+Wind=Storm
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wind],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wind],
               Result1 = AlchemyElements.Elements[ElementIndexes.Storm],
            },
            // Wind+Pressure=Storm
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wind],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Storm],
            },
            // Air+Steam=Cloud
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Steam],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cloud],
            },
            // Air+Cloud=Sky
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Cloud],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sky],
            },
            // Cloud+Cloud=Sky
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cloud],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Cloud],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sky],
            },
            // Cloud+Energy=Storm
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cloud],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Energy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Storm],
            },
            // Storm+Energy=Tornado
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Storm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Energy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tornado],
            },
            // Storm+Storm=Tornado
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Storm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Storm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tornado],
            },
            // Cloud+Water=Rain
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cloud],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Rain],
            },
            // Cloud+Ice=Snow
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cloud],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ice],
               Result1 = AlchemyElements.Elements[ElementIndexes.Snow],
            },
            // Energy+Metal=Electricity
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Energy],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Electricity],
            },
            // Storm+Electricity=Thunderstorm
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Storm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Electricity],
               Result1 = AlchemyElements.Elements[ElementIndexes.Thunderstorm],
            },
            // Thunderstorm+Water=Rain
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Thunderstorm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Rain],
            },
            // Electricity+Glass=Lightbulb
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Electricity],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Glass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lightbulb],
            },
            // Lightbulb+Electricity=Light
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lightbulb],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Electricity],
               Result1 = AlchemyElements.Elements[ElementIndexes.Light],
            },
            // Light+Rain=Rainbow
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Light],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Rain],
               Result1 = AlchemyElements.Elements[ElementIndexes.Rainbow],
            },
            // Sky+Light=Sun
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sky],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Light],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sun],
            },
            // Bird+Ice=Penguin
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bird],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ice],
               Result1 = AlchemyElements.Elements[ElementIndexes.Penguin],
            },
            // Clay+Fire=Brick
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Clay],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Brick],
            },
            // Earth+Worm=Beetle
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Worm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Beetle],
            },
            // Earth+Algae=Mushroom
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Algae],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mushroom],
            },
            // Water+Seed=Flower
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Water],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Seed],
               Result1 = AlchemyElements.Elements[ElementIndexes.Flower],
            },
            // Flower+Tree=Fruit
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Flower],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fruit],
            },
            // Fruit+Water=Watermelon
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fruit],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Watermelon],
            },
            // Stone+Sky=Moon
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Stone],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sky],
               Result1 = AlchemyElements.Elements[ElementIndexes.Moon],
            },
            // Planet+Planet=Solarsystem
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Planet],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Planet],
               Result1 = AlchemyElements.Elements[ElementIndexes.Solarsystem],
            },
            // Solarsystem+Solarsystem=Galaxy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Solarsystem],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Solarsystem],
               Result1 = AlchemyElements.Elements[ElementIndexes.Galaxy],
            },
            // Sun+Sun=Galaxy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sun],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sun],
               Result1 = AlchemyElements.Elements[ElementIndexes.Galaxy],
            },
            // Galaxy+Galaxy=Universe
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Galaxy],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Galaxy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Universe],
            },
            // Air+Worm=Butterfly
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Worm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Butterfly],
            },
            // Turtle+Turtle=Turtle+Turtle+Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Turtle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Turtle],
               Result1 = AlchemyElements.Elements[ElementIndexes.Turtle],
               Result2 = AlchemyElements.Elements[ElementIndexes.Turtle],
               Result3 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Tortoise+Tortoise=Tortoise+Tortoise+Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tortoise],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tortoise],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tortoise],
               Result2 = AlchemyElements.Elements[ElementIndexes.Tortoise],
               Result3 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Beetle+Air=Fly
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beetle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fly],
            },
            // Dinosaur+Ocean=Plesiosaur
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ocean],
               Result1 = AlchemyElements.Elements[ElementIndexes.Plesiosaur],
            },
            // Dinosaur+Air=Pterosaur
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pterosaur],
            },
            // Dinosaur+Fire=Dragon
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dragon],
            },
            // Dragon+Fly=Dragonfly
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dragon],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fly],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dragonfly],
            },
            // Dragon+Man=Ash
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dragon],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ash],
            },
            // Beast+Earth=Tiger
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tiger],
            },
            // Sky+Lightbulb=Star
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sky],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Lightbulb],
               Result1 = AlchemyElements.Elements[ElementIndexes.Star],
            },
            // Star+Fish=Starfish
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Star],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fish],
               Result1 = AlchemyElements.Elements[ElementIndexes.Starfish],
            },
            // Metal+Tool=Arm+Knife+Tool
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Metal],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Arm],
               Result2 = AlchemyElements.Elements[ElementIndexes.Knife],
               Result3 = AlchemyElements.Elements[ElementIndexes.Tool],
            },
            // Arm+Man=Hunter
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Arm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hunter],
            },
            // Hunter+Arm=Warrior
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Hunter],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Arm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Warrior],
            },
            // Arm+Light=Lightsaber
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Arm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Light],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lightsaber],
            },
            // Arm+Gunpowder=Firearm
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Arm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Gunpowder],
               Result1 = AlchemyElements.Elements[ElementIndexes.Firearm],
            },
            // Firearm+Warrior=Soldier
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Firearm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Warrior],
               Result1 = AlchemyElements.Elements[ElementIndexes.Soldier],
            },
            // Desert+Tree=Cactus
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Desert],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cactus],
            },
            // Hunter+Fish=Fisherman
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Hunter],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fish],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fisherman],
            },
            // Snake+Tool=Poison
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Snake],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Poison],
            },
            // Mushroom+Tool=Poison
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mushroom],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Poison],
            },
            // Mushroom+Algae=Lichen
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mushroom],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Algae],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lichen],
            },
            // Mushroom+Bacteria=Lichen
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mushroom],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bacteria],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lichen],
            },
            // Poison+Man=Corpse
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Poison],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Corpse],
            },
            // Poison+Fish=Fugu
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Poison],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fish],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fugu],
            },
            // Poison+Arm=Poisonedweapon
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Poison],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Arm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Poisonedweapon],
            },
            // Poisonedweapon+Man=Assassin
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Poisonedweapon],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Assassin],
            },
            // Assassin+Lightsaber=Sith
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Assassin],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Lightsaber],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sith],
            },
            // Warrior+Lightsaber=Jedi
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Warrior],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Lightsaber],
               Result1 = AlchemyElements.Elements[ElementIndexes.Jedi],
            },
            // Sith+Jedi=DarthVader
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sith],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Jedi],
               Result1 = AlchemyElements.Elements[ElementIndexes.DarthVader],
            },
            // Bacteria+Water=Plankton
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bacteria],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Plankton],
            },
            // Fish+Plankton=Whale
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fish],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Plankton],
               Result1 = AlchemyElements.Elements[ElementIndexes.Whale],
            },
            // Plankton+Stone=Shell
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Plankton],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Stone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Shell],
            },
            // Shell+Stone=Limestone
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Shell],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Stone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Limestone],
            },
            // Sand+Shell=Pearl
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sand],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Shell],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pearl],
            },
            // Shell+Worm=Snail
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Shell],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Worm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Snail],
            },
            // Limestone+Fire=Lime
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Limestone],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lime],
            },
            // Limestone+Clay=Cement
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Limestone],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Clay],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cement],
            },
            // Cement+Water=Concrete
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cement],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Concrete],
            },
            // Mushroom+Mud=Mold+Yeast
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mushroom],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Mud],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mold],
               Result2 = AlchemyElements.Elements[ElementIndexes.Yeast],
            },
            // Mold+Milk=Cheese
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mold],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Milk],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cheese],
            },
            // Cheese+Beast=Mouse
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cheese],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beast],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mouse],
            },
            // Mouse+Hunter=Cat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mouse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hunter],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cat],
            },
            // Mouse+Cat=TomandJerry
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mouse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Cat],
               Result1 = AlchemyElements.Elements[ElementIndexes.TomandJerry],
            },
            // Cheese+Fire=Fondue
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cheese],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fondue],
            },
            // Swamp+Algae=Moss
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Swamp],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Algae],
               Result1 = AlchemyElements.Elements[ElementIndexes.Moss],
            },
            // Moss+Swamp=Fern
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Moss],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Swamp],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fern],
            },
            // Fern+Earth=Fossil
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fern],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fossil],
            },
            // Mold+Earth=Moss
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mold],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Moss],
            },
            // Moss+Earth=Grass
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Moss],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Grass],
            },
            // Grass+Grass=Seed
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Grass],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Grass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Seed],
            },
            // Grass+Livestock=Livestock+Milk+Manure
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Grass],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Livestock],
               Result1 = AlchemyElements.Elements[ElementIndexes.Livestock],
               Result2 = AlchemyElements.Elements[ElementIndexes.Milk],
               Result3 = AlchemyElements.Elements[ElementIndexes.Manure],
            },
            // Milk+Bacteria=Yogurt
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Milk],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bacteria],
               Result1 = AlchemyElements.Elements[ElementIndexes.Yogurt],
            },
            // Air+Bacteria=Flu
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bacteria],
               Result1 = AlchemyElements.Elements[ElementIndexes.Flu],
            },
            // Air+Electricity=Ozone
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Air],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Electricity],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ozone],
            },
            // Bird+Metal=Airplane
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bird],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Airplane],
            },
            // Earth+Tool=Arable
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Arable],
            },
            // Earth+Plankton=Worm
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Plankton],
               Result1 = AlchemyElements.Elements[ElementIndexes.Worm],
            },
            // Butterfly+Earth=Fossil
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Butterfly],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fossil],
            },
            // Dinosaur+Earth=Fossil
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fossil],
            },
            // Pterosaur+Earth=Fossil
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pterosaur],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fossil],
            },
            // Steam+Earth=Geyser
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Steam],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Geyser],
            },
            // Arable+Seed=Wheat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Arable],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Seed],
               Result1 = AlchemyElements.Elements[ElementIndexes.Wheat],
            },
            // Wheat+Tool=Flour
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wheat],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Flour],
            },
            // Flour+Water=Dough
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Flour],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dough],
            },
            // Dough+Fire=Bread
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dough],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bread],
            },
            // Dough+Cheese=Pizza
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dough],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Cheese],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pizza],
            },
            // Dough+Fruit=Pie
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dough],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fruit],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pie],
            },
            // Fossil+Pressure=Kerogen
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fossil],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Kerogen],
            },
            // Kerogen+Pressure=Bitumen
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Kerogen],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bitumen],
            },
            // Bitumen+Pressure=Petroleum
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bitumen],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Petroleum],
            },
            // Petroleum+Pressure=Gasoline
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Petroleum],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Gasoline],
            },
            // Beetle+Sand=Scorpion
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beetle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sand],
               Result1 = AlchemyElements.Elements[ElementIndexes.Scorpion],
            },
            // Scorpion+Tool=Poison+Tool
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Scorpion],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Poison],
               Result2 = AlchemyElements.Elements[ElementIndexes.Tool],
            },
            // Scorpion+Scorpion=Scorpion+Scorpion+Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Scorpion],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Scorpion],
               Result1 = AlchemyElements.Elements[ElementIndexes.Scorpion],
               Result2 = AlchemyElements.Elements[ElementIndexes.Scorpion],
               Result3 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Beetle+Cactus=Cochineal
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beetle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Cactus],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cochineal],
            },
            // Cochineal+Fire=Carmine
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cochineal],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Carmine],
            },
            // Beetle+Manure=Scarab
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beetle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Manure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Scarab],
            },
            // Beetle+Beetle=TheBeatles
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beetle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beetle],
               Result1 = AlchemyElements.Elements[ElementIndexes.TheBeatles],
            },
            // Tool+Tree=Wood+Tool
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tool],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result2 = AlchemyElements.Elements[ElementIndexes.Tool],
            },
            // Tool+Forest=Wood+Tool
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tool],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Forest],
               Result1 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result2 = AlchemyElements.Elements[ElementIndexes.Tool],
            },
            // Tool+Wood=Wheel
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tool],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Wheel],
            },
            // Wheel+Wheel=Bicycle
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wheel],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wheel],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bicycle],
            },
            // Wheel+Wood=Wagon
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wheel],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Wagon],
            },
            // Fire+Wood=Ash+Coal
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ash],
               Result2 = AlchemyElements.Elements[ElementIndexes.Coal],
            },
            // Fire+Tree=Ash+Ash+Coal
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ash],
               Result2 = AlchemyElements.Elements[ElementIndexes.Ash],
               Result3 = AlchemyElements.Elements[ElementIndexes.Coal],
            },
            // Coal+Fire=Energy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Coal],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Energy],
            },
            // Coal+Pressure=Uncutdiamond
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Coal],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Uncutdiamond],
            },
            // Uncutdiamond+Tool=Diamond
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Uncutdiamond],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Diamond],
            },
            // Coal+Boiler=Steamengine
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Coal],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Boiler],
               Result1 = AlchemyElements.Elements[ElementIndexes.Steamengine],
            },
            // Metal+Steam=Boiler
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Metal],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Steam],
               Result1 = AlchemyElements.Elements[ElementIndexes.Boiler],
            },
            // Boiler+Steam=Pressure
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Boiler],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Steam],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pressure],
            },
            // Wagon+Steamengine=Locomotive
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wagon],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Steamengine],
               Result1 = AlchemyElements.Elements[ElementIndexes.Locomotive],
            },
            // Steamengine+Gasoline=Combustionengine
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Steamengine],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Gasoline],
               Result1 = AlchemyElements.Elements[ElementIndexes.Combustionengine],
            },
            // Wagon+Combustionengine=Car
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wagon],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Combustionengine],
               Result1 = AlchemyElements.Elements[ElementIndexes.Car],
            },
            // Bicycle+Combustionengine=Motorcycle
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bicycle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Combustionengine],
               Result1 = AlchemyElements.Elements[ElementIndexes.Motorcycle],
            },
            // Boat+Combustionengine=Motorboat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Boat],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Combustionengine],
               Result1 = AlchemyElements.Elements[ElementIndexes.Motorboat],
            },
            // Water+Wood=Boat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Water],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Boat],
            },
            // Wood+Boat=Woodenship
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wood],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Boat],
               Result1 = AlchemyElements.Elements[ElementIndexes.Woodenship],
            },
            // Woodenship+Steamengine=Steamer
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Woodenship],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Steamengine],
               Result1 = AlchemyElements.Elements[ElementIndexes.Steamer],
            },
            // Corpse+Wood=Coffin
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Coffin],
            },
            // Wood+Life=Pinocchio
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wood],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pinocchio],
            },
            // Earth+Wood=Grape
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Grape],
            },
            // Fruit+Bacteria=Alcohol
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fruit],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bacteria],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
            },
            // Alcohol+Grape=Wine
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Grape],
               Result1 = AlchemyElements.Elements[ElementIndexes.Wine],
            },
            // Alcohol+Bread=Beer
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bread],
               Result1 = AlchemyElements.Elements[ElementIndexes.Beer],
            },
            // Alcohol+Worm=Tequila
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Worm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tequila],
            },
            // Alcohol+Flower=Perfume
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Flower],
               Result1 = AlchemyElements.Elements[ElementIndexes.Perfume],
            },
            // Alcohol+Water=Vodka
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Vodka],
            },
            // Yeast+Wheat=Alcohol
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Yeast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wheat],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
            },
            // Wood+Pressure=Paper
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wood],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Paper],
            },
            // Man+Paper=Book
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paper],
               Result1 = AlchemyElements.Elements[ElementIndexes.Book],
            },
            // Book+Book=Library
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Book],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Book],
               Result1 = AlchemyElements.Elements[ElementIndexes.Library],
            },
            // Book+Fire=Ash
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Book],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ash],
            },
            // Man+Stone=Hut
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Stone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hut],
            },
            // Brick+Concrete=House
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Brick],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Concrete],
               Result1 = AlchemyElements.Elements[ElementIndexes.House],
            },
            // House+Concrete=Skyscraper
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.House],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Concrete],
               Result1 = AlchemyElements.Elements[ElementIndexes.Skyscraper],
            },
            // Skyscraper+Skyscraper=City
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Skyscraper],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Skyscraper],
               Result1 = AlchemyElements.Elements[ElementIndexes.City],
            },
            // City+City=Country
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.City],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.City],
               Result1 = AlchemyElements.Elements[ElementIndexes.Country],
            },
            // Country+Country=Continent
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Country],
               Result1 = AlchemyElements.Elements[ElementIndexes.Continent],
            },
            // Continent+Ocean=Planet
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Continent],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ocean],
               Result1 = AlchemyElements.Elements[ElementIndexes.Planet],
            },
            // Planet+Sun=Solarsystem
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Planet],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sun],
               Result1 = AlchemyElements.Elements[ElementIndexes.Solarsystem],
            },
            // Life+Hourglass=Time
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Life],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hourglass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Time],
            },
            // Time+Man=Oldman
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Time],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Oldman],
            },
            // Tree+Lightbulb=Christmastree
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tree],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Lightbulb],
               Result1 = AlchemyElements.Elements[ElementIndexes.Christmastree],
            },
            // Christmastree+Oldman=Santaclaus
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Christmastree],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Oldman],
               Result1 = AlchemyElements.Elements[ElementIndexes.Santaclaus],
            },
            // Man+Snow=Snowman
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Snow],
               Result1 = AlchemyElements.Elements[ElementIndexes.Snowman],
            },
            // Man+Library=Scientist
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Library],
               Result1 = AlchemyElements.Elements[ElementIndexes.Scientist],
            },
            // Scientist+Mold=Penicillin
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Scientist],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Mold],
               Result1 = AlchemyElements.Elements[ElementIndexes.Penicillin],
            },
            // Livestock+Man=Man+Meat+Milk+Wool
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Livestock],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Man],
               Result2 = AlchemyElements.Elements[ElementIndexes.Meat],
               Result3 = AlchemyElements.Elements[ElementIndexes.Milk],
               Result4 = AlchemyElements.Elements[ElementIndexes.Wool],
            },
            // Meat+Fire=Barbeque
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Meat],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Barbeque],
            },
            // Wool+Tool=Cloth
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wool],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cloth],
            },
            // Cloth+Tool=Clothing
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cloth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Clothing],
            },
            // Knife+Knife=Scissors
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Knife],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Knife],
               Result1 = AlchemyElements.Elements[ElementIndexes.Scissors],
            },
            // Water+Electricity=Hydrogen+Oxygen
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Water],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Electricity],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hydrogen],
               Result2 = AlchemyElements.Elements[ElementIndexes.Oxygen],
            },
            // Oxygen+Man=Carbondioxide
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Oxygen],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Carbondioxide],
            },
            // Carbondioxide+Water=Sodawater
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Carbondioxide],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sodawater],
            },
            // Sodawater+Carmine=CocaCola
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sodawater],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Carmine],
               Result1 = AlchemyElements.Elements[ElementIndexes.CocaCola],
            },
            // Chicken+Chicken=Chicken+Chicken+Egg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Chicken],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Chicken],
               Result1 = AlchemyElements.Elements[ElementIndexes.Chicken],
               Result2 = AlchemyElements.Elements[ElementIndexes.Chicken],
               Result3 = AlchemyElements.Elements[ElementIndexes.Egg],
            },
            // Corpse+Paper=Mummy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paper],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mummy],
            },
            // Limestone+Limestone=Pyramid
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Limestone],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Limestone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pyramid],
            },
            // Pyramid+Mummy=Anubis
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pyramid],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Mummy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Anubis],
            },
            // Pyramid+Man=Pharaoh
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pyramid],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pharaoh],
            },
            // Corpse+Fire=Ash
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ash],
            },
            // Corpse+Life=Zombie
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Zombie],
            },
            // Corpse+Energy=Zombie
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Energy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Zombie],
            },
            // Corpse+Electricity=Frankenstein
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Electricity],
               Result1 = AlchemyElements.Elements[ElementIndexes.Frankenstein],
            },
            // Earth+Corpse=Grave
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Corpse],
               Result1 = AlchemyElements.Elements[ElementIndexes.Grave],
            },
            // Grave+Grave=Cemetery
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Grave],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Grave],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cemetery],
            },
            // Assassin+Man=Assassin+Corpse
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Assassin],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Assassin],
               Result2 = AlchemyElements.Elements[ElementIndexes.Corpse],
            },
            // Assassin+Assassin=Corpse+Corpse
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Assassin],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Assassin],
               Result1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               Result2 = AlchemyElements.Elements[ElementIndexes.Corpse],
            },
            // Man+Warrior=Blood+Corpse+Warrior
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Warrior],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blood],
               Result2 = AlchemyElements.Elements[ElementIndexes.Corpse],
               Result3 = AlchemyElements.Elements[ElementIndexes.Warrior],
            },
            // Coffin+Earth=Grave
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Coffin],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Grave],
            },
            // Cloth+Boat=Sailboat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cloth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Boat],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sailboat],
            },
            // Man+Flu=Sick
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Flu],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sick],
            },
            // Sick+Penicillin=Man
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sick],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Penicillin],
               Result1 = AlchemyElements.Elements[ElementIndexes.Man],
            },
            // House+Sick=Hospital
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.House],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sick],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hospital],
            },
            // House+Fossil=Museum
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.House],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fossil],
               Result1 = AlchemyElements.Elements[ElementIndexes.Museum],
            },
            // House+Beer=Bar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.House],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beer],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bar],
            },
            // House+Tequila=Bar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.House],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tequila],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bar],
            },
            // Museum+Beast=Zoo
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Museum],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beast],
               Result1 = AlchemyElements.Elements[ElementIndexes.Zoo],
            },
            // Bird+Hunter=Feather+Meat+Hunter
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bird],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hunter],
               Result1 = AlchemyElements.Elements[ElementIndexes.Feather],
               Result2 = AlchemyElements.Elements[ElementIndexes.Meat],
               Result3 = AlchemyElements.Elements[ElementIndexes.Hunter],
            },
            // Feather+Cloth=Pillow
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Feather],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Cloth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pillow],
            },
            // Feather+Snake=Quetzalcoatl
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Feather],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Snake],
               Result1 = AlchemyElements.Elements[ElementIndexes.Quetzalcoatl],
            },
            // Mouse+Air=Bat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mouse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bat],
            },
            // Bat+Man=Batman
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bat],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Batman],
            },
            // Blood+Man=Vampire
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blood],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Vampire],
            },
            // Man+Vampire=Vampire+Vampire
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result2 = AlchemyElements.Elements[ElementIndexes.Vampire],
            },
            // Blood+Vampire=Vampire
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blood],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Vampire],
            },
            // Beast+Vampire=Werewolf
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Werewolf],
            },
            // Bird+Vampire=Bat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bird],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bat],
            },
            // Sun+Vampire=Sun+Ash
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sun],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sun],
               Result2 = AlchemyElements.Elements[ElementIndexes.Ash],
            },
            // Vampire+Werewolf=TwilightSaga
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Vampire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Werewolf],
               Result1 = AlchemyElements.Elements[ElementIndexes.TwilightSaga],
            },
            // Man+Man=Sex+Love
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sex],
               Result2 = AlchemyElements.Elements[ElementIndexes.Love],
            },
            // Sex+City=SexandtheCity
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sex],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.City],
               Result1 = AlchemyElements.Elements[ElementIndexes.SexandtheCity],
            },
            // Sex+Book=Kamasutra
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sex],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Book],
               Result1 = AlchemyElements.Elements[ElementIndexes.Kamasutra],
            },
            // Kamasutra+Man=Sex
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Kamasutra],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sex],
            },
            // Warrior+Wagon=Chariot
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Warrior],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wagon],
               Result1 = AlchemyElements.Elements[ElementIndexes.Chariot],
            },
            // Sky+Chariot=Sun
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sky],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Chariot],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sun],
            },
            // Grass+Fruit=Berry
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Grass],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fruit],
               Result1 = AlchemyElements.Elements[ElementIndexes.Berry],
            },
            // Chicken+Hut=Hencoop
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Chicken],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hut],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hencoop],
            },
            // Chicken+Flu=Avianflu
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Chicken],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Flu],
               Result1 = AlchemyElements.Elements[ElementIndexes.Avianflu],
            },
            // Mud+Livestock=Pig
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mud],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Livestock],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pig],
            },
            // Pig+Flu=Swineflu
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pig],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Flu],
               Result1 = AlchemyElements.Elements[ElementIndexes.Swineflu],
            },
            // Pig+Fire=Bacon
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pig],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bacon],
            },
            // Pig+Man=Fat+Meat+Man
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pig],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fat],
               Result2 = AlchemyElements.Elements[ElementIndexes.Meat],
               Result3 = AlchemyElements.Elements[ElementIndexes.Man],
            },
            // Ash+Fat=Soap
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ash],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fat],
               Result1 = AlchemyElements.Elements[ElementIndexes.Soap],
            },
            // Forest+Rain=Jungle
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Forest],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Rain],
               Result1 = AlchemyElements.Elements[ElementIndexes.Jungle],
            },
            // Jungle+Book=JungleBook
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Jungle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Book],
               Result1 = AlchemyElements.Elements[ElementIndexes.JungleBook],
            },
            // Dragon+Warrior=Hero+Blood
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dragon],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Warrior],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hero],
               Result2 = AlchemyElements.Elements[ElementIndexes.Blood],
            },
            // Hero+Forest=RobinHood
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Hero],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Forest],
               Result1 = AlchemyElements.Elements[ElementIndexes.RobinHood],
            },
            // Car+Ocean=Submarine
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Car],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ocean],
               Result1 = AlchemyElements.Elements[ElementIndexes.Submarine],
            },
            // Ocean+Stone=Island
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ocean],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Stone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Island],
            },
            // Airplane+Man=Pilot
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Airplane],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pilot],
            },
            // Woodenship+Man=Captain
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Woodenship],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Captain],
            },
            // Steamer+Man=Captain
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Steamer],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Captain],
            },
            // Submarine+Captain=CaptainNemo
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Submarine],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Captain],
               Result1 = AlchemyElements.Elements[ElementIndexes.CaptainNemo],
            },
            // Woodenship+Assassin=Pirate
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Woodenship],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Assassin],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pirate],
            },
            // Pirate+Woodenship=Pirateship
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pirate],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Woodenship],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pirateship],
            },
            // Pirate+Island=Treasure
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pirate],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Island],
               Result1 = AlchemyElements.Elements[ElementIndexes.Treasure],
            },
            // Bread+Meat=Sandwich
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bread],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Meat],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sandwich],
            },
            // Bread+Barbeque=Sandwich
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bread],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Barbeque],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sandwich],
            },
            // Sandwich+CocaCola=McDonalds
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sandwich],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.CocaCola],
               Result1 = AlchemyElements.Elements[ElementIndexes.McDonalds],
            },
            // RobinHood+Arm=Bow
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.RobinHood],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Arm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bow],
            },
            // Bow+Rain=Rainbow
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bow],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Rain],
               Result1 = AlchemyElements.Elements[ElementIndexes.Rainbow],
            },
            // Brick+Water=Dam
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Brick],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dam],
            },
            // Dam+Beast=Beaver
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Dam],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beast],
               Result1 = AlchemyElements.Elements[ElementIndexes.Beaver],
            },
            // Beaver+Wood=Dam
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beaver],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dam],
            },
            // Beaver+Tree=Dam
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beaver],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dam],
            },
            // Carbondioxide+Wine=Champagne
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Carbondioxide],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wine],
               Result1 = AlchemyElements.Elements[ElementIndexes.Champagne],
            },
            // Wine+Sodawater=Champagne
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wine],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sodawater],
               Result1 = AlchemyElements.Elements[ElementIndexes.Champagne],
            },
            // Clay+Man=Ceramics
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Clay],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ceramics],
            },
            // Ghost+Energy=Ectoplasm
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ghost],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Energy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ectoplasm],
            },
            // Grass+Swamp=Reed
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Grass],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Swamp],
               Result1 = AlchemyElements.Elements[ElementIndexes.Reed],
            },
            // Reed+Tool=Paper
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Reed],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Paper],
            },
            // Fire+Grass=Tobacco
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Grass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tobacco],
            },
            // Tobacco+Fire=Ash+Smoke
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tobacco],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ash],
               Result2 = AlchemyElements.Elements[ElementIndexes.Smoke],
            },
            // Tobacco+Paper=Cigarettes
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tobacco],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paper],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cigarettes],
            },
            // Cigarettes+Man=Cancer
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cigarettes],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cancer],
            },
            // Cigarettes+Fire=Ash+Smoke
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Cigarettes],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ash],
               Result2 = AlchemyElements.Elements[ElementIndexes.Smoke],
            },
            // Scientist+Metal=Alchemist
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Scientist],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alchemist],
            },
            // Alchemist+Metal=Gold
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alchemist],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Gold],
            },
            // Radio+Energy=Radioactivity
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Radio],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Energy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Radioactivity],
            },
            // Radioactivity+Earth=Uranium
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Radioactivity],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Uranium],
            },
            // Uranium+Scientist=Plutonium
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Uranium],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Scientist],
               Result1 = AlchemyElements.Elements[ElementIndexes.Plutonium],
            },
            // Plutonium+Arm=Atomicbomb
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Plutonium],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Arm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Atomicbomb],
            },
            // Atomicbomb+Hydrogen=Hydrogenbomb
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Atomicbomb],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hydrogen],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hydrogenbomb],
            },
            // Gold+Gold=Treasure
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Gold],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Gold],
               Result1 = AlchemyElements.Elements[ElementIndexes.Treasure],
            },
            // Galaxy+Life=Alien
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Galaxy],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alien],
            },
            // Solarsystem+Life=Alien
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Solarsystem],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alien],
            },
            // Star+Airplane=Starship
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Star],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Airplane],
               Result1 = AlchemyElements.Elements[ElementIndexes.Starship],
            },
            // Star+Hero=CaptainPicard
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Star],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hero],
               Result1 = AlchemyElements.Elements[ElementIndexes.CaptainPicard],
            },
            // CaptainPicard+Starship=USSEnterprise
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.CaptainPicard],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Starship],
               Result1 = AlchemyElements.Elements[ElementIndexes.USSEnterprise],
            },
            // Star+Time=Supernova
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Star],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Time],
               Result1 = AlchemyElements.Elements[ElementIndexes.Supernova],
            },
            // Gunpowder+Fire=Explosion+Smoke
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Gunpowder],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Explosion],
               Result2 = AlchemyElements.Elements[ElementIndexes.Smoke],
            },
            // Gasoline+Fire=Explosion
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Gasoline],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Explosion],
            },
            // Supernova+Explosion=Blackhole
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Supernova],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Explosion],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
            },
            // Galaxy+Worm=Wormhole
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Galaxy],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Worm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Wormhole],
            },
            // Blackhole+Light=Blackhole+Void
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Light],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               Result2 = AlchemyElements.Elements[ElementIndexes.Void],
            },
            // Blackhole+Star=Blackhole+Void
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Star],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               Result2 = AlchemyElements.Elements[ElementIndexes.Void],
            },
            // Blackhole+Sun=Blackhole+Void
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sun],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               Result2 = AlchemyElements.Elements[ElementIndexes.Void],
            },
            // Blackhole+Solarsystem=Blackhole+Void
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Solarsystem],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               Result2 = AlchemyElements.Elements[ElementIndexes.Void],
            },
            // Blackhole+Galaxy=Blackhole+Void
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Galaxy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               Result2 = AlchemyElements.Elements[ElementIndexes.Void],
            },
            // Void+Explosion=BigBang
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Void],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Explosion],
               Result1 = AlchemyElements.Elements[ElementIndexes.BigBang],
            },
            // Universe+Time=BigCrunch
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Universe],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Time],
               Result1 = AlchemyElements.Elements[ElementIndexes.BigCrunch],
            },
            // Man+Lightbulb=Idea
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Lightbulb],
               Result1 = AlchemyElements.Elements[ElementIndexes.Idea],
            },
            // Blackhole+Scientist=StephenHawking
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blackhole],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Scientist],
               Result1 = AlchemyElements.Elements[ElementIndexes.StephenHawking],
            },
            // Universe+Scientist=AlbertEinstein
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Universe],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Scientist],
               Result1 = AlchemyElements.Elements[ElementIndexes.AlbertEinstein],
            },
            // AlbertEinstein+Idea=Relativitytheory
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.AlbertEinstein],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Idea],
               Result1 = AlchemyElements.Elements[ElementIndexes.Relativitytheory],
            },
            // Light+Glass=Lamp
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Light],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Glass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lamp],
            },
            // Lamp+Lava=Lavalamp
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lamp],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Lava],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lavalamp],
            },
            // Lamp+Ghost=Genie
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lamp],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ghost],
               Result1 = AlchemyElements.Elements[ElementIndexes.Genie],
            },
            // Assassin+Time=Prisoner
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Assassin],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Time],
               Result1 = AlchemyElements.Elements[ElementIndexes.Prisoner],
            },
            // Life+Limestone=Coral
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Life],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Limestone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Coral],
            },
            // Beetle+Car=VWBeetle
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beetle],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Car],
               Result1 = AlchemyElements.Elements[ElementIndexes.VWBeetle],
            },
            // Fire+Bread=Toast
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bread],
               Result1 = AlchemyElements.Elements[ElementIndexes.Toast],
            },
            // Mushroom+Life=OneUP
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mushroom],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.OneUP],
            },
            // OneUP+Man=Mario
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.OneUP],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mario],
            },
            // Mario+Dinosaur=Yoshi
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mario],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               Result1 = AlchemyElements.Elements[ElementIndexes.Yoshi],
            },
            // OneUP+Dinosaur=Yoshi
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.OneUP],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Dinosaur],
               Result1 = AlchemyElements.Elements[ElementIndexes.Yoshi],
            },
            // Yoshi+Egg=Yoshiegg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Yoshi],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Egg],
               Result1 = AlchemyElements.Elements[ElementIndexes.Yoshiegg],
            },
            // Yoshi+Mario=Team
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Yoshi],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Mario],
               Result1 = AlchemyElements.Elements[ElementIndexes.Team],
            },
            // OneUP+Ghost=Boomushroom
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.OneUP],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ghost],
               Result1 = AlchemyElements.Elements[ElementIndexes.Boomushroom],
            },
            // Mario+Computer=Computergame
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mario],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Computer],
               Result1 = AlchemyElements.Elements[ElementIndexes.Computergame],
            },
            // Mario+Team=Luigi
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mario],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Team],
               Result1 = AlchemyElements.Elements[ElementIndexes.Luigi],
            },
            // Pharaoh+Country=King
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pharaoh],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Country],
               Result1 = AlchemyElements.Elements[ElementIndexes.King],
            },
            // Blood+Worm=Leach
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blood],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Worm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Leach],
            },
            // Leach+King=LichKing
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Leach],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.King],
               Result1 = AlchemyElements.Elements[ElementIndexes.LichKing],
            },
            // LichKing+Computergame=Warcraft
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.LichKing],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Computergame],
               Result1 = AlchemyElements.Elements[ElementIndexes.Warcraft],
            },
            // Fire+Life=Fireelemental
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fireelemental],
            },
            // Mite+Earth=Ant
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Mite],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Earth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ant],
            },
            // Ant+Wood=Termite
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ant],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Termite],
            },
            // Ant+Termite=Insects
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ant],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Termite],
               Result1 = AlchemyElements.Elements[ElementIndexes.Insects],
            },
            // Insects+Air=Mosquito
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Insects],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mosquito],
            },
            // Insects+Jungle=Mantis
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Insects],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Jungle],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mantis],
            },
            // House+Termite=Infestation
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.House],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Termite],
               Result1 = AlchemyElements.Elements[ElementIndexes.Infestation],
            },
            // Computer+Life=Robot
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Computer],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Life],
               Result1 = AlchemyElements.Elements[ElementIndexes.Robot],
            },
            // Alien+Infestation=Zerg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alien],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Infestation],
               Result1 = AlchemyElements.Elements[ElementIndexes.Zerg],
            },
            // Alien+Robot=Protoss
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alien],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Robot],
               Result1 = AlchemyElements.Elements[ElementIndexes.Protoss],
            },
            // Zerg+Protoss=Starcraft
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Zerg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Protoss],
               Result1 = AlchemyElements.Elements[ElementIndexes.Starcraft],
            },
            // Zerg+Hero=QueenofBlades
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Zerg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hero],
               Result1 = AlchemyElements.Elements[ElementIndexes.QueenofBlades],
            },
            // Protoss+Hero=Zeratul
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Protoss],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hero],
               Result1 = AlchemyElements.Elements[ElementIndexes.Zeratul],
            },
            // Starcraft+Man=Terran
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Starcraft],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Terran],
            },
            // Terran+Hero=JimRaynor
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Terran],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hero],
               Result1 = AlchemyElements.Elements[ElementIndexes.JimRaynor],
            },
            // Computergame+Car=NeedforSpeed
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Computergame],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Car],
               Result1 = AlchemyElements.Elements[ElementIndexes.NeedforSpeed],
            },
            // Computergame+Zombie=ResidentEvil
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Computergame],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Zombie],
               Result1 = AlchemyElements.Elements[ElementIndexes.ResidentEvil],
            },
            // Computergame+Grave=TombRaider
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Computergame],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Grave],
               Result1 = AlchemyElements.Elements[ElementIndexes.TombRaider],
            },
            // TombRaider+Hero=LaraCroft
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.TombRaider],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hero],
               Result1 = AlchemyElements.Elements[ElementIndexes.LaraCroft],
            },
            // Carmine+Water=Paint
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Carmine],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Water],
               Result1 = AlchemyElements.Elements[ElementIndexes.Paint],
            },
            // Egg+Diamond=Fabergeegg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Egg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Diamond],
               Result1 = AlchemyElements.Elements[ElementIndexes.Fabergeegg],
            },
            // Egg+Paint=Easteregg
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Egg],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paint],
               Result1 = AlchemyElements.Elements[ElementIndexes.Easteregg],
            },
            // Light+House=Lighthouse
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Light],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.House],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lighthouse],
            },
            // Lizard+Swamp=Frog
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lizard],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Swamp],
               Result1 = AlchemyElements.Elements[ElementIndexes.Frog],
            },
            // Lizard+Fire=Salamander
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lizard],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Salamander],
            },
            // Man+Yogurt=Diet
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Yogurt],
               Result1 = AlchemyElements.Elements[ElementIndexes.Diet],
            },
            // Man+McDonalds=Obesity
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.McDonalds],
               Result1 = AlchemyElements.Elements[ElementIndexes.Obesity],
            },
            // Obesity+Diet=Man
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Obesity],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Diet],
               Result1 = AlchemyElements.Elements[ElementIndexes.Man],
            },
            // Water+Metal=Rust
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Water],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Rust],
            },
            // Bird+Fire=Phoenix
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bird],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Phoenix],
            },
            // Assassin+Firearm=Sniper
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Assassin],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Firearm],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sniper],
            },
            // Fish+Algae=Sushi
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fish],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Algae],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sushi],
            },
            // Blood+Bird=Vulture
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blood],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bird],
               Result1 = AlchemyElements.Elements[ElementIndexes.Vulture],
            },
            // Flour+Beetle=Weevil
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Flour],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beetle],
               Result1 = AlchemyElements.Elements[ElementIndexes.Weevil],
            },
            // Corpse+Zombie=Undead
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Zombie],
               Result1 = AlchemyElements.Elements[ElementIndexes.Undead],
            },
            // Wine+Bacteria=Vinegar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wine],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Bacteria],
               Result1 = AlchemyElements.Elements[ElementIndexes.Vinegar],
            },
            // Wheel+Wool=Spinningwheel
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wheel],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Spinningwheel],
            },
            // Spinningwheel+Wool=Yarn
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Spinningwheel],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Yarn],
            },
            // Earth+Metal=Aluminium
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Aluminium],
            },
            // Frog+Beast=Kangaroo
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Frog],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beast],
               Result1 = AlchemyElements.Elements[ElementIndexes.Kangaroo],
            },
            // Country+Vodka=Russia
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vodka],
               Result1 = AlchemyElements.Elements[ElementIndexes.Russia],
            },
            // Country+Vampire=Romania
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Romania],
            },
            // Country+McDonalds=USA
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.McDonalds],
               Result1 = AlchemyElements.Elements[ElementIndexes.USA],
            },
            // Country+CocaCola=USA
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.CocaCola],
               Result1 = AlchemyElements.Elements[ElementIndexes.USA],
            },
            // Country+Wine=France
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wine],
               Result1 = AlchemyElements.Elements[ElementIndexes.France],
            },
            // Country+Champagne=France
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Champagne],
               Result1 = AlchemyElements.Elements[ElementIndexes.France],
            },
            // Country+Beer=Germany
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beer],
               Result1 = AlchemyElements.Elements[ElementIndexes.Germany],
            },
            // Country+VWBeetle=Germany
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.VWBeetle],
               Result1 = AlchemyElements.Elements[ElementIndexes.Germany],
            },
            // Country+AlbertEinstein=Germany
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.AlbertEinstein],
               Result1 = AlchemyElements.Elements[ElementIndexes.Germany],
            },
            // Country+RobinHood=UK
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.RobinHood],
               Result1 = AlchemyElements.Elements[ElementIndexes.UK],
            },
            // Country+StephenHawking=UK
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.StephenHawking],
               Result1 = AlchemyElements.Elements[ElementIndexes.UK],
            },
            // Country+TheBeatles=UK
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.TheBeatles],
               Result1 = AlchemyElements.Elements[ElementIndexes.UK],
            },
            // Country+Panda=China
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Panda],
               Result1 = AlchemyElements.Elements[ElementIndexes.China],
            },
            // Country+Dragon=China
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Dragon],
               Result1 = AlchemyElements.Elements[ElementIndexes.China],
            },
            // Country+Mummy=Egypt
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Mummy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Egypt],
            },
            // Country+Anubis=Egypt
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Anubis],
               Result1 = AlchemyElements.Elements[ElementIndexes.Egypt],
            },
            // Country+Pizza=Italy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pizza],
               Result1 = AlchemyElements.Elements[ElementIndexes.Italy],
            },
            // Country+Mario=Italy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Mario],
               Result1 = AlchemyElements.Elements[ElementIndexes.Italy],
            },
            // Country+Diamond=SouthAfrica
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Diamond],
               Result1 = AlchemyElements.Elements[ElementIndexes.SouthAfrica],
            },
            // Country+Uncutdiamond=SouthAfrica
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Uncutdiamond],
               Result1 = AlchemyElements.Elements[ElementIndexes.SouthAfrica],
            },
            // Country+Tequila=Mexico
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tequila],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mexico],
            },
            // Country+Kamasutra=India
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Kamasutra],
               Result1 = AlchemyElements.Elements[ElementIndexes.India],
            },
            // Country+Sushi=Japan
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sushi],
               Result1 = AlchemyElements.Elements[ElementIndexes.Japan],
            },
            // Country+Ice=Iceland
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ice],
               Result1 = AlchemyElements.Elements[ElementIndexes.Iceland],
            },
            // Country+Fondue=Switzerland
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fondue],
               Result1 = AlchemyElements.Elements[ElementIndexes.Switzerland],
            },
            // Country+Kangaroo=Australia
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Kangaroo],
               Result1 = AlchemyElements.Elements[ElementIndexes.Australia],
            },
            // Country+Pirate=Somalia
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pirate],
               Result1 = AlchemyElements.Elements[ElementIndexes.Somalia],
            },
            // Country+Petroleum=SaudiArabia
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Petroleum],
               Result1 = AlchemyElements.Elements[ElementIndexes.SaudiArabia],
            },
            // Romania+Vampire=Dracula
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Romania],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dracula],
            },
            // France+Hero=Napoleon
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.France],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hero],
               Result1 = AlchemyElements.Elements[ElementIndexes.Napoleon],
            },
            // Continent+Penguin=Antarctica
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Continent],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Penguin],
               Result1 = AlchemyElements.Elements[ElementIndexes.Antarctica],
            },
            // Country+Jungle=Brazil
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Jungle],
               Result1 = AlchemyElements.Elements[ElementIndexes.Brazil],
            },
            // Country+PolarBear=Canada
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.PolarBear],
               Result1 = AlchemyElements.Elements[ElementIndexes.Canada],
            },
            // Country+Fish=Norway
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fish],
               Result1 = AlchemyElements.Elements[ElementIndexes.Norway],
            },
            // Robot+Book=KarelCapek
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Robot],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Book],
               Result1 = AlchemyElements.Elements[ElementIndexes.KarelCapek],
            },
            // Country+KarelCapek=CzechRepublic
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.KarelCapek],
               Result1 = AlchemyElements.Elements[ElementIndexes.CzechRepublic],
            },
            // Steam+Man=Sauna
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Steam],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sauna],
            },
            // Country+Sauna=Finland
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sauna],
               Result1 = AlchemyElements.Elements[ElementIndexes.Finland],
            },
            // Country+Dam=Netherlands
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Dam],
               Result1 = AlchemyElements.Elements[ElementIndexes.Netherlands],
            },
            // Alcohol+Cactus=Tequila
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Cactus],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tequila],
            },
            // Corpse+Cloth=Mummy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Corpse],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Cloth],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mummy],
            },
            // Alcohol+Wheat=Vodka
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wheat],
               Result1 = AlchemyElements.Elements[ElementIndexes.Vodka],
            },
            // Beer+Man=Alcoholic
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beer],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alcoholic],
            },
            // Vodka+Man=Alcoholic
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Vodka],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alcoholic],
            },
            // Alcohol+Man=Alcoholic
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alcoholic],
            },
            // Tequila+Man=Alcoholic
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tequila],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Alcoholic],
            },
            // Ash+Glass=Ashtray
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ash],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Glass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ashtray],
            },
            // Sun+Rain=Tropics
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sun],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Rain],
               Result1 = AlchemyElements.Elements[ElementIndexes.Tropics],
            },
            // Reed+Tropics=SugarCane
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Reed],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tropics],
               Result1 = AlchemyElements.Elements[ElementIndexes.SugarCane],
            },
            // SugarCane+Tool=Sugar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.SugarCane],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sugar],
            },
            // Sugar+Fire=Caramel
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sugar],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Caramel],
            },
            // Time+Tool=Clock
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Time],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Clock],
            },
            // Warrior+Fire=Firefighter
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Warrior],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Firefighter],
            },
            // Fire+Fly=Firefly
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fire],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Fly],
               Result1 = AlchemyElements.Elements[ElementIndexes.Firefly],
            },
            // Light+Beetle=Firefly
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Light],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Beetle],
               Result1 = AlchemyElements.Elements[ElementIndexes.Firefly],
            },
            // Grape+Pressure=Juice
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Grape],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Juice],
            },
            // Fruit+Pressure=Juice
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fruit],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Juice],
            },
            // Thunderstorm+Metal=LightningRod
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Thunderstorm],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.LightningRod],
            },
            // Aluminium+Glass=Mirror
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Aluminium],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Glass],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mirror],
            },
            // Swamp+Tree=Peat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Swamp],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Peat],
            },
            // Swamp+Pressure=Peat
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Swamp],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Pressure],
               Result1 = AlchemyElements.Elements[ElementIndexes.Peat],
            },
            // Knife+Tool=SwissArmyKnife
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Knife],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.SwissArmyKnife],
            },
            // Switzerland+Knife=SwissArmyKnife
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Switzerland],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Knife],
               Result1 = AlchemyElements.Elements[ElementIndexes.SwissArmyKnife],
            },
            // Alcohol+Peat=ScotchWhiskey
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Alcohol],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Peat],
               Result1 = AlchemyElements.Elements[ElementIndexes.ScotchWhiskey],
            },
            // ScotchWhiskey+Country=Scotland
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.ScotchWhiskey],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Country],
               Result1 = AlchemyElements.Elements[ElementIndexes.Scotland],
            },
            // Japan+Warrior=Samurai
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Japan],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Warrior],
               Result1 = AlchemyElements.Elements[ElementIndexes.Samurai],
            },
            // Milk+Tree=Rubber
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Milk],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tree],
               Result1 = AlchemyElements.Elements[ElementIndexes.Rubber],
            },
            // Rubber+Air=Ball
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Rubber],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ball],
            },
            // Man+Ball=Football
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ball],
               Result1 = AlchemyElements.Elements[ElementIndexes.Football],
            },
            // Lightsaber+Lightsaber=StarWars
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Lightsaber],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Lightsaber],
               Result1 = AlchemyElements.Elements[ElementIndexes.StarWars],
            },
            // StarWars+Robot=R2D2+C3PO
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.StarWars],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Robot],
               Result1 = AlchemyElements.Elements[ElementIndexes.R2D2],
               Result2 = AlchemyElements.Elements[ElementIndexes.C3PO],
            },
            // Water+Scorpion=Lobster
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Water],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Scorpion],
               Result1 = AlchemyElements.Elements[ElementIndexes.Lobster],
            },
            // Beast+Desert=Camel
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Beast],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Desert],
               Result1 = AlchemyElements.Elements[ElementIndexes.Camel],
            },
            // Stone+Tool=Statue
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Stone],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Statue],
            },
            // Statue+Statue=Monument
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Statue],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Statue],
               Result1 = AlchemyElements.Elements[ElementIndexes.Monument],
            },
            // Statue+USA=LibertyStatue
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Statue],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.USA],
               Result1 = AlchemyElements.Elements[ElementIndexes.LibertyStatue],
            },
            // Monument+USA=LibertyStatue
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Monument],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.USA],
               Result1 = AlchemyElements.Elements[ElementIndexes.LibertyStatue],
            },
            // Monument+France=EiffelTower
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Monument],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.France],
               Result1 = AlchemyElements.Elements[ElementIndexes.EiffelTower],
            },
            // Monument+Italy=Colosseum
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Monument],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Italy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Colosseum],
            },
            // Monument+UK=BigBen
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Monument],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.UK],
               Result1 = AlchemyElements.Elements[ElementIndexes.BigBen],
            },
            // Monument+India=TajMahal
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Monument],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.India],
               Result1 = AlchemyElements.Elements[ElementIndexes.TajMahal],
            },
            // Monument+Egypt=Pyramid
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Monument],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Egypt],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pyramid],
            },
            // King+Paper=Playcards
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.King],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paper],
               Result1 = AlchemyElements.Elements[ElementIndexes.Playcards],
            },
            // Ocean+Ghost=Jellyfish
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ocean],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ghost],
               Result1 = AlchemyElements.Elements[ElementIndexes.Jellyfish],
            },
            // Hospital+Car=Ambulance
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Hospital],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Car],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ambulance],
            },
            // Wind+Metal=Sound
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wind],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sound],
            },
            // Sound+Idea=Music
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sound],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Idea],
               Result1 = AlchemyElements.Elements[ElementIndexes.Music],
            },
            // Music+Tool=Guitar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Music],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Guitar],
            },
            // Guitar+Hero=GuitarHero
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Guitar],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Hero],
               Result1 = AlchemyElements.Elements[ElementIndexes.GuitarHero],
            },
            // Team+Team=Sport
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Team],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Team],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sport],
            },
            // Sport+Car=F1
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sport],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Car],
               Result1 = AlchemyElements.Elements[ElementIndexes.F1],
            },
            // Sport+UK=Football
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sport],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.UK],
               Result1 = AlchemyElements.Elements[ElementIndexes.Football],
            },
            // Sport+Romania=Gymnastics
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sport],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Romania],
               Result1 = AlchemyElements.Elements[ElementIndexes.Gymnastics],
            },
            // Sport+China=TableTennis
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sport],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.China],
               Result1 = AlchemyElements.Elements[ElementIndexes.TableTennis],
            },
            // Sport+USA=AmericanFootball
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sport],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.USA],
               Result1 = AlchemyElements.Elements[ElementIndexes.AmericanFootball],
            },
            // Sport+Canada=Hockey
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sport],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Canada],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hockey],
            },
            // Sport+Australia=Rugby
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sport],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Australia],
               Result1 = AlchemyElements.Elements[ElementIndexes.Rugby],
            },
            // Sport+India=Cricket
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sport],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.India],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cricket],
            },
            // F1+Team=Ferrari
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.F1],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Team],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ferrari],
            },
            // Car+Italy=Ferrari
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Car],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Italy],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ferrari],
            },
            // Car+USA=Ford
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Car],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.USA],
               Result1 = AlchemyElements.Elements[ElementIndexes.Ford],
            },
            // Car+Germany=Mercedes+Audi+BWM
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Car],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Germany],
               Result1 = AlchemyElements.Elements[ElementIndexes.Mercedes],
               Result2 = AlchemyElements.Elements[ElementIndexes.Audi],
               Result3 = AlchemyElements.Elements[ElementIndexes.BWM],
            },
            // Car+France=Renault
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Car],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.France],
               Result1 = AlchemyElements.Elements[ElementIndexes.Renault],
            },
            // Car+Japan=Toyota+Nissan
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Car],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Japan],
               Result1 = AlchemyElements.Elements[ElementIndexes.Toyota],
               Result2 = AlchemyElements.Elements[ElementIndexes.Nissan],
            },
            // Football+UK=ManUtd+Chelsea+Arsenal+Liverpool
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Football],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.UK],
               Result1 = AlchemyElements.Elements[ElementIndexes.ManUtd],
               Result2 = AlchemyElements.Elements[ElementIndexes.Chelsea],
               Result3 = AlchemyElements.Elements[ElementIndexes.Arsenal],
               Result4 = AlchemyElements.Elements[ElementIndexes.Liverpool],
            },
            // Paper+Paint=Picture
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Paper],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paint],
               Result1 = AlchemyElements.Elements[ElementIndexes.Picture],
            },
            // Picture+Tool=Camera
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Picture],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Camera],
            },
            // Picture+Picture=Movie
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Picture],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Picture],
               Result1 = AlchemyElements.Elements[ElementIndexes.Movie],
            },
            // Movie+House=Theater
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Movie],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.House],
               Result1 = AlchemyElements.Elements[ElementIndexes.Theater],
            },
            // Movie+Statue=Oscar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Movie],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Statue],
               Result1 = AlchemyElements.Elements[ElementIndexes.Oscar],
            },
            // Wind+Air=Sound
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Wind],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Air],
               Result1 = AlchemyElements.Elements[ElementIndexes.Sound],
            },
            // Penguin+Computer=Linux
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Penguin],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Computer],
               Result1 = AlchemyElements.Elements[ElementIndexes.Linux],
            },
            // Man+Paint=Artist
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paint],
               Result1 = AlchemyElements.Elements[ElementIndexes.Artist],
            },
            // Rain+Ice=Hail
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Rain],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ice],
               Result1 = AlchemyElements.Elements[ElementIndexes.Hail],
            },
            // House+Airplane=Airport
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.House],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Airplane],
               Result1 = AlchemyElements.Elements[ElementIndexes.Airport],
            },
            // Computer+Man=Geek
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Computer],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Geek],
            },
            // Geek+Computergame=Nerd
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Geek],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Computergame],
               Result1 = AlchemyElements.Elements[ElementIndexes.Nerd],
            },
            // Fish+Wind=Blowfish
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fish],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wind],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blowfish],
            },
            // Man+Music=Musician
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Music],
               Result1 = AlchemyElements.Elements[ElementIndexes.Musician],
            },
            // Man+Star=Astronaut
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Star],
               Result1 = AlchemyElements.Elements[ElementIndexes.Astronaut],
            },
            // Scientist+Idea=Science
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Scientist],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Idea],
               Result1 = AlchemyElements.Elements[ElementIndexes.Science],
            },
            // Hydrogen+Science=Chemistry
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Hydrogen],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Chemistry],
            },
            // Oxygen+Science=Chemistry
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Oxygen],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Chemistry],
            },
            // Carbondioxide+Science=Chemistry
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Carbondioxide],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Chemistry],
            },
            // Life+Science=Biology
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Life],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Biology],
            },
            // AlbertEinstein+Science=Physics
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.AlbertEinstein],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Physics],
            },
            // StephenHawking+Science=Physics
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.StephenHawking],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Physics],
            },
            // Earth+Science=Geology
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Earth],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Geology],
            },
            // Fossil+Science=Paleontology
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Fossil],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Paleontology],
            },
            // Universe+Science=Astronomy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Universe],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Astronomy],
            },
            // Galaxy+Science=Astronomy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Galaxy],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Astronomy],
            },
            // Planet+Science=Astronomy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Planet],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Astronomy],
            },
            // Solarsystem+Science=Astronomy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Solarsystem],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Astronomy],
            },
            // Biology+Scientist=CharlesDarwin
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Biology],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Scientist],
               Result1 = AlchemyElements.Elements[ElementIndexes.CharlesDarwin],
            },
            // Whale+Book=MobyDick
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Whale],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Book],
               Result1 = AlchemyElements.Elements[ElementIndexes.MobyDick],
            },
            // Ocean+Limestone=Chalk
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Ocean],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Limestone],
               Result1 = AlchemyElements.Elements[ElementIndexes.Chalk],
            },
            // Chalk+Wood=Blackboard
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Chalk],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Wood],
               Result1 = AlchemyElements.Elements[ElementIndexes.Blackboard],
            },
            // Blackboard+Man=Student
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Blackboard],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Student],
            },
            // Student+House=School
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Student],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.House],
               Result1 = AlchemyElements.Elements[ElementIndexes.School],
            },
            // School+Car=Schoolbus
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.School],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Car],
               Result1 = AlchemyElements.Elements[ElementIndexes.Schoolbus],
            },
            // Sound+Music=Soundofmusic
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sound],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Music],
               Result1 = AlchemyElements.Elements[ElementIndexes.Soundofmusic],
            },
            // Gold+Paper=Money
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Gold],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paper],
               Result1 = AlchemyElements.Elements[ElementIndexes.Money],
            },
            // Treasure+Paper=Money
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Treasure],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paper],
               Result1 = AlchemyElements.Elements[ElementIndexes.Money],
            },
            // Country+Money=Economy
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Country],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Money],
               Result1 = AlchemyElements.Elements[ElementIndexes.Economy],
            },
            // Science+Money=Economics
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Science],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Money],
               Result1 = AlchemyElements.Elements[ElementIndexes.Economics],
            },
            // USA+Money=Dollar
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.USA],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Money],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dollar],
            },
            // France+Money=Euro
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.France],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Money],
               Result1 = AlchemyElements.Elements[ElementIndexes.Euro],
            },
            // Germany+Money=Euro
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Germany],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Money],
               Result1 = AlchemyElements.Elements[ElementIndexes.Euro],
            },
            // Italy+Money=Euro
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Italy],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Money],
               Result1 = AlchemyElements.Elements[ElementIndexes.Euro],
            },
            // UK+Money=Pound
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.UK],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Money],
               Result1 = AlchemyElements.Elements[ElementIndexes.Pound],
            },
            // Euro+Continent=Europe
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Euro],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Continent],
               Result1 = AlchemyElements.Elements[ElementIndexes.Europe],
            },
            // Money+House=Bank
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Money],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.House],
               Result1 = AlchemyElements.Elements[ElementIndexes.Bank],
            },
            // Bank+Metal=Vault
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bank],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Metal],
               Result1 = AlchemyElements.Elements[ElementIndexes.Vault],
            },
            // Petroleum+Tool=Plastic
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Petroleum],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Tool],
               Result1 = AlchemyElements.Elements[ElementIndexes.Plastic],
            },
            // Money+Plastic=Creditcard
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Money],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Plastic],
               Result1 = AlchemyElements.Elements[ElementIndexes.Creditcard],
            },
            // Paper+Paper=Box
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Paper],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Paper],
               Result1 = AlchemyElements.Elements[ElementIndexes.Box],
            },
            // Box+Box=Container
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Box],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Box],
               Result1 = AlchemyElements.Elements[ElementIndexes.Container],
            },
            // Container+Container=Cargo
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Container],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Container],
               Result1 = AlchemyElements.Elements[ElementIndexes.Cargo],
            },
            // Metal+Box=Safe
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Metal],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Box],
               Result1 = AlchemyElements.Elements[ElementIndexes.Safe],
            },
            // Bank+Box=Depositbox
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bank],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Box],
               Result1 = AlchemyElements.Elements[ElementIndexes.Depositbox],
            },
            // Tool+Box=Toolbox
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Tool],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Box],
               Result1 = AlchemyElements.Elements[ElementIndexes.Toolbox],
            },
            // Plastic+Box=Basket
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Plastic],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Box],
               Result1 = AlchemyElements.Elements[ElementIndexes.Basket],
            },
            // Basket+Ball=Basketball
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Basket],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ball],
               Result1 = AlchemyElements.Elements[ElementIndexes.Basketball],
            },
            // Safe+Man=Helmet
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Safe],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Helmet],
            },
            // Helmet+Man=Work
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Helmet],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Work],
            },
            // Work+Man=Worker
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Work],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Man],
               Result1 = AlchemyElements.Elements[ElementIndexes.Worker],
            },
            // Worker+Worker=Company
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Worker],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Worker],
               Result1 = AlchemyElements.Elements[ElementIndexes.Company],
            },
            // Work+House=Factory
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Work],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.House],
               Result1 = AlchemyElements.Elements[ElementIndexes.Factory],
            },
            // Work+Factory=Product
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Work],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Factory],
               Result1 = AlchemyElements.Elements[ElementIndexes.Product],
            },
            // Christmastree+Santaclaus=Christmas
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Christmastree],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Santaclaus],
               Result1 = AlchemyElements.Elements[ElementIndexes.Christmas],
            },
            // Christmas+Product=Gift
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Christmas],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Product],
               Result1 = AlchemyElements.Elements[ElementIndexes.Gift],
            },
            // Gift+Box=Giftbox
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Gift],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Box],
               Result1 = AlchemyElements.Elements[ElementIndexes.Giftbox],
            },
            // Sound+Box=Soundmixer+Speakers
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sound],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Box],
               Result1 = AlchemyElements.Elements[ElementIndexes.Soundmixer],
               Result2 = AlchemyElements.Elements[ElementIndexes.Speakers],
            },
            // Man+Sound=Language
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Man],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Sound],
               Result1 = AlchemyElements.Elements[ElementIndexes.Language],
            },
            // Language+Science=Linguistics
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Language],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Science],
               Result1 = AlchemyElements.Elements[ElementIndexes.Linguistics],
            },
            // Pyramid+Country=Egypt
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Pyramid],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Country],
               Result1 = AlchemyElements.Elements[ElementIndexes.Egypt],
            },
            // Bat+Vampire=Dracula
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Bat],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Vampire],
               Result1 = AlchemyElements.Elements[ElementIndexes.Dracula],
            },
            // Sun+Ice=Water
            new AlchemyCombination
            {
               InputElement1 = AlchemyElements.Elements[ElementIndexes.Sun],
               InputElement2 = AlchemyElements.Elements[ElementIndexes.Ice],
               Result1 = AlchemyElements.Elements[ElementIndexes.Water],
            },
         };
      }

      public static AlchemyCombination[] Combinations
      {
         get {return combinations;}
      }
   }
}