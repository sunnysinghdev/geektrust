import weather

ORBIT1 = "ORBIT1"
ORBIT2 = "ORBIT2"

class Orbit:
    def __init__(self, name, distance, crater):
        self.name = name
        self.distance = distance
        self.crater = crater

    def set_caret(self, weatherType):
        if(weatherType == weather.SUNNY):
            self.crater = int(self.crater - (self.crater * 10/100))
        elif (weatherType == weather.RAINY):
            self.crater = int(self.crater + (self.crater * 20/100))

    def set_speed(self, speed):
        self.speed = int(speed)