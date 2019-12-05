class Batalion:
    def __init__(self, name, maxStrength, strength, prevBatalion, nextBatalion):
        self.name = name
        self.maxStrength = maxStrength
        self.strength = strength
        self.orignalStrength = strength
        self.nextBatalion = nextBatalion
        self.prevBatalion = prevBatalion
