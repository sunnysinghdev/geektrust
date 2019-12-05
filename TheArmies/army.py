import math
class Army:
    def __init__(self, hMax, eMax, atMax, sgMax, power):
        self.maxHorses = hMax
        self.maxElephants = eMax
        self.maxTanks = atMax
        self.maxGuns = sgMax
        self.power = power

    def enemy_batalions(self, batalions):
        for key in batalions:
            batalion = batalions[key]
            batalion.strength = math.ceil(batalion.strength / self.power)
        self.batalions = batalions

    def war_result(self):
        loses = False
        batalions = self.batalions
        for key in batalions:
            batalion = batalions[key]
            curStrength = batalion.strength * 2
            if(batalion.orignalStrength > curStrength):
                prevStrength, nextStrength = 0, 0
                if batalion.prevBatalion in batalions:
                    prevBat = batalions[batalion.prevBatalion]
                    if prevBat.orignalStrength < prevBat.strength * 2:
                        prevStrength = math.floor(
                            ((prevBat.strength * 2) - prevBat.orignalStrength) / 2)
                if batalion.nextBatalion in batalions:
                    nextBat = batalions[batalion.nextBatalion]
                    if nextBat.orignalStrength < nextBat.strength * 2:
                        nextStrength = ((nextBat.strength * 2) -
                                        nextBat.orignalStrength) * 2
                if (batalion.orignalStrength > (prevStrength + curStrength + nextStrength)):
                    loses = True
        return loses

    def attack(self):
        batalions = self.batalions
        for key in batalions:
            batalion = batalions[key]
            if(batalion.strength > batalion.maxStrength):
                requireStrength = (batalion.strength - batalion.maxStrength)
                if(batalion.prevBatalion in batalions):
                    prevBat = batalions[batalion.prevBatalion]
                    if(prevBat.strength < prevBat.maxStrength):
                        newStrength = requireStrength * 2
                        if(prevBat.strength + newStrength) <= prevBat.maxStrength:
                            prevBat.strength = prevBat.strength + newStrength
                            batalion.strength = batalion.maxStrength
                        else:
                            requireStrength = math.ceil(
                                (prevBat.strength + newStrength - prevBat.maxStrength)/2)
                            prevBat.strength = prevBat.maxStrength
                            batalion.strength = batalion.maxStrength
                    else:
                        batalion.strength = batalion.maxStrength
                if(batalion.nextBatalion in batalions):
                    nextBat = batalions[batalion.nextBatalion]
                    if(nextBat.strength < nextBat.maxStrength and requireStrength > 0):
                        requireStrength = math.ceil(requireStrength / 2)
                        if(nextBat.strength + requireStrength) <= nextBat.maxStrength:
                            nextBat.strength = nextBat.strength + requireStrength
                            batalion.strength = batalion.maxStrength
                        else:
                            nextBat.strength = nextBat.maxStrength
                            batalion.strength = batalion.maxStrength
                else:
                    batalion.strength = batalion.maxStrength
        self.batalions = batalions
