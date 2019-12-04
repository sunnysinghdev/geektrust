import crypto

AIR = "AIR"
SPACE = "SPACE"
ICE = "ICE"
LAND = "LAND"
WATER = "WATER"
FIRE = "FIRE"

OWL = "OWL"
GORILLA = "GORILLA"
PANDA = "PANDA"
OCTOPUS = "OCTOPUS"
MAMMOTH = "MAMMOTH"
DRAGON = "DRAGON"


class Kingdom:
    def __init__(self, name, emblem):
        self.name = name
        self.emblem = emblem

    def is_allegiance(self, encryptedMsg):
        decryptedMsg = crypto.decrypt(len(self.emblem), encryptedMsg)
        charDict = dict()
        #Calulate no of occurences of each character
        for c in self.emblem:
            if(c not in charDict):
                charDict[c] = 0
                for c2 in self.emblem:
                    if(c == c2):
                        charDict[c] = charDict[c] + 1
        for key in charDict:
            if(decryptedMsg.count(key) < charDict[key]):
                return False
        return True
        

