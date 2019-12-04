
import weather
import sys
import vehicle
import orbit

HIGH = 3
MEDIUM = 2
LOW = 1

orbits = dict()
vehicles = dict()


def init_orbit():
    orbits[orbit.ORBIT1] = orbit.Orbit(orbit.ORBIT1, 18, 20)
    orbits[orbit.ORBIT2] = orbit.Orbit(orbit.ORBIT2, 20, 10)


def init_vehicle():
    vehicles[vehicle.BIKE] = vehicle.Vehicle(vehicle.BIKE, 10, 2, HIGH)
    vehicles[vehicle.TUKTUK] = vehicle.Vehicle(vehicle.TUKTUK, 12, 1, MEDIUM)
    vehicles[vehicle.CAR] = vehicle.Vehicle(vehicle.CAR, 20, 3, LOW)


output = ""


def check_fastest_travel_option(input_file):
    global output
    try:
        file = open(input_file, "r")
        for line in file:
            #line = input_file
            feild = line.split(" ")
            weatherType = feild[0].upper()
            speed1 = feild[1]
            speed2 = feild[2]

            orbit1 = orbits[orbit.ORBIT1]
            orbit1.set_caret(weatherType)
            orbit1.set_speed(speed1)

            orbit2 = orbits[orbit.ORBIT2]
            orbit2.set_caret(weatherType)
            orbit2.set_speed(speed2)

            availableVehicles = available_vehicles(weatherType)

            minTime = 999999
            fastestVehicle = None
            orbitName = orbit.ORBIT2

            for key in orbits:
                for vehicle in availableVehicles:
                    timeTaken = vehicle.get_travel_time(orbits[key])
                    if(minTime >= timeTaken):
                        orbitName = key
                        if(minTime == timeTaken):
                            if(fastestVehicle is None):
                                fastestVehicle = vehicle
                            else:
                                if(fastestVehicle.priority < vehicle.priority):
                                    fastestVehicle = vehicle
                        else:
                            fastestVehicle = vehicle
                        minTime = timeTaken

                    #print(vehicle.name + "  " + str(timeTaken))
            output = fastestVehicle.name + " " + orbitName
    except:
        pass
    return output


def available_vehicles(weatherType):
    vList = []
    if(weatherType == weather.SUNNY):
        for key in vehicles:
            vList.append(vehicles[key])
    elif(weatherType == weather.RAINY):
        for key in vehicles:
            if(key != vehicle.BIKE):
                vList.append(vehicles[key])
    elif weatherType == weather.WINDY:
        for key in vehicles:
            if(key != vehicle.TUKTUK):
                vList.append(vehicles[key])

    return vList


init_orbit()
init_vehicle()
argumentList = sys.argv
if(len(argumentList) > 1):
    input_file = argumentList[1]
    print(check_fastest_travel_option(input_file))
