import sys

def read_commands(input_file, splitter):
    cmdList = []
    try:
        file = open(input_file, "r")
        for line in file:
            feilds = line.replace("\n","").split(splitter)
            cmdList.append(feilds)
    except:
        pass
    return cmdList

def get_input_file(argv):
    if len(argv) > 1:
        return argv[1]
    return None

def print_list(lines):
    for line in lines:
        print(line)