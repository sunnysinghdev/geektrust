BIKE = "BIKE"
CAR = "CAR"
TUKTUK = "TUKTUK"

class Vehicle:
    def __init__(self, name, speed, caretTravelTime, priority):
        self.name = name
        self.speed = speed
        self.caretTravelTime = caretTravelTime
        self.priority = priority

    def get_travel_time(self, orbit):
        self.orbitName = orbit.name
        travelSpeed = 0
        craterTime = orbit.crater * self.caretTravelTime

        if(orbit.speed < self.speed):
            travelSpeed = orbit.speed
        else:
            travelSpeed = self.speed

        travelTime = (orbit.distance / travelSpeed) * 60

        return craterTime + travelTime