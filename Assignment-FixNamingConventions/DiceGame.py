# Assignment 1: The below program is to Roll the Dice

import random

def roll_die(sides):
      return random.randint(1, sides)

def dice_game():

      sides = 6

      keep_playing = True

      while keep_playing:

            user_input = input("Ready to roll? Enter Q to Quit: ")

            if user_input.lower() != "q":

                  result = roll_die(sides)
                  print("You have rolled a", result)

            else:
                  keep_playing = False

dice_game()