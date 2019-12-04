import sys
import kingdom

kingdoms = dict()
output = "None"
kingdomsEmblem = {
    kingdom.SPACE: kingdom.GORILLA,
    kingdom.LAND: kingdom.PANDA,
    kingdom.WATER: kingdom.OCTOPUS,
    kingdom.ICE: kingdom.MAMMOTH,
    kingdom.AIR: kingdom.OWL,
    kingdom.FIRE: kingdom.DRAGON,
}


def init_kindoms():
    for kd in kingdomsEmblem:
        kingdoms[kd] = kingdom.Kingdom(kd, kingdomsEmblem[kd])

def check_allegiance_kingdoms(input_file):
    allegianceKingdoms = []
    global output
    try:
        file = open(input_file, "r")
        for line in file:
            feild = line.split(" ")
            kingdomName = feild[0].upper()
            kingdomMsg = line[len(kingdomName) + 1:].upper().replace("\n", "")
            #print(kingdomMsg)
            if(kingdomName in kingdoms):
                if(kingdoms[kingdomName].is_allegiance(kingdomMsg)):
                    allegianceKingdoms.append(kingdomName)
        #print(allegianceKingdoms)
        if(len(allegianceKingdoms) > 2):
            output = kingdom.SPACE + " "
            for kd in allegianceKingdoms:
                output = output + kd + " "
    except:
        pass
    return output

#------------------------------------------------------------------------------
#------------------------Program Start-----------------------------------------
#------------------------------------------------------------------------------
init_kindoms()
argumentList = sys.argv
if(len(argumentList) > 1):
    input_file = argumentList[1]
    print(check_allegiance_kingdoms(input_file))
else:
    print(output)
