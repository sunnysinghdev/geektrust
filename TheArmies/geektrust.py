import sys
import math
from batalion import Batalion
from army import Army

HORSE = "H"
ELEPHANT = "E"
ARMOURED_TANK = "AT"
SLING_GUNS = "SG"

def attack(input_file):
    lengaburuArmy = Army(100, 50, 10, 5, 2)
    batalions = read_batalions(input_file, lengaburuArmy)
    lengaburuArmy.enemy_batalions(batalions)
    lengaburuArmy.attack()
    loses = lengaburuArmy.war_result()
    batalions = lengaburuArmy.batalions

    output = "{}H {}E {}AT {}SG".format(
        batalions[HORSE].strength, 
        batalions[ELEPHANT].strength, 
        batalions[ARMOURED_TANK].strength, 
        batalions[SLING_GUNS].strength)
    if(loses):
        print("LOSES " + output)
    else:
        print("WINS " + output)


def read_batalions(input_file, lengaburuArmy):
    file = open(input_file, "r")
    for line in file:
        fields = line.split(" ")
        fields.pop(0)
        #print(fields)
        batalions = dict()

        for val in fields:
            if HORSE in val:
                count = int(val.replace(HORSE, ""))
                batalions[HORSE] = Batalion(
                    HORSE, lengaburuArmy.maxHorses, count, "", ELEPHANT)
            elif ELEPHANT in val:
                count = int(val.replace(ELEPHANT, ""))
                batalions[ELEPHANT] = Batalion(
                    ELEPHANT, lengaburuArmy.maxElephants, count, HORSE, ARMOURED_TANK)
            elif ARMOURED_TANK in val:
                count = int(val.replace(ARMOURED_TANK, ""))
                batalions[ARMOURED_TANK] = Batalion(
                    ARMOURED_TANK, lengaburuArmy.maxTanks, count, ELEPHANT, SLING_GUNS)
            elif SLING_GUNS in val:
                count = int(val.replace(SLING_GUNS, ""))
                batalions[SLING_GUNS] = Batalion(
                    SLING_GUNS, lengaburuArmy.maxGuns, count, ARMOURED_TANK, "")

        return batalions

#---------------------------------------------------------------------------------
#---------------------------------------------------------------------------------
argumentList = sys.argv
if(len(argumentList) > 1):
    input_file = argumentList[1]
    attack(input_file)

