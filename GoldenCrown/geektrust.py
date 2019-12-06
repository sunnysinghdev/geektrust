import sys
import kingdom
import crypto
import CONST_KINGDOM_NAME
from emblem import kingdomsEmblem

def init_kindoms():
    kingdoms = dict()
    for kd in kingdomsEmblem:
        kingdoms[kd] = kingdom.Kingdom(kd, kingdomsEmblem[kd])
    return kingdoms

def read_kingdoms_message(input_file):
    kingdomsList = []
    try:
        file = open(input_file, "r")
        for line in file:
            feild = line.split(" ")
            kingdomName = feild[0].upper()
            kingdomMsg = line[len(kingdomName) + 1:].upper().replace("\n", "")
            kingdomsList.append((kingdomName, kingdomMsg))
    except:
        pass
    return kingdomsList

def get_input_file():
    argumentList = sys.argv
    input_file = None
    if(len(argumentList) > 1):
        input_file = argumentList[1]

    return input_file

def execute():
    output = "None"
    input_file = get_input_file()
    #input_file = "./test_sample1.txt"
    if(input_file is not None):
        kingdomList = read_kingdoms_message(input_file)
        kingdoms = init_kindoms()
        
        ruler = kingdoms[CONST_KINGDOM_NAME.SPACE]
        ruler.init_allegiance_kingdoms(kingdomList, kingdoms)
        output = ruler.output()

    print(output)
# ------------------------------------------------------------------------------
# ------------------------Program Start-----------------------------------------
# ------------------------------------------------------------------------------
execute()
