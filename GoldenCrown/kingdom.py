import crypto
import utils
class Kingdom:
    def __init__(self, name, emblem):
        self.name = name
        self.emblem = emblem
        self.allegianceKingdoms = []

    def is_allegiance(self, encryptedMsg):
        decryptedMsg = crypto.decrypt(len(self.emblem), encryptedMsg)
        charDict = dict()
        #Calulate no of occurences of each character
        for c in self.emblem:
            if(c not in charDict):
                charDict[c] = self.emblem.count(c)
                
        for key in charDict:
            if(decryptedMsg.count(key) < charDict[key]):
                return False
        return True
    
    def init_allegiance_kingdoms(self, kingdomList, kingdoms):
        allegianceKingdoms = []
        for kd in kingdomList:
            kingdomName = kd[0]
            kingdomMsg = kd[1]
            # Get list of allegiance kindoms
            if(kingdomName in kingdoms and kingdomName != self.name and kingdoms[kingdomName].is_allegiance(kingdomMsg)):
                allegianceKingdoms.append(kingdomName)
        #allegianceKingdoms.remove(self.name)
        allegianceKingdoms = utils.remove_duplicates(allegianceKingdoms)
        self.allegianceKingdoms  = allegianceKingdoms
    
    def output(self):
        forKingdomName = self.name
        kdList = self.allegianceKingdoms
        output = "None"
        if(len(kdList) > 2):
            output = forKingdomName + " "
            for kd in kdList:
                #if(kd != forKingdomName):
                output = output + kd + " "
        return output