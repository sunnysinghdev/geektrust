import sys
def read_commands(input_file):
    cmdList = []
    try:
        file = open(input_file, "r")
        for line in file:
            feilds = line.replace("\n","").split(" ")
            cmdList.append(feilds)
    except:
        print("Eroor")
    return cmdList

def get_input_file(argv):
    if len(argv) > 1:
        return argv[1]
    return None

