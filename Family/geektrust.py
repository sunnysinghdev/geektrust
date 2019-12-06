import sys

import utils
import CONST_COMMAND
import CONST_RELATION
from person import Person
from commands import ChildCommand, RelationshipCommand

def get_command(params):
    cmd = params[0]
    command = None
    try:
        if(cmd == CONST_COMMAND.ADD_CHILD):
            motherName = params[1]
            childName = params[2]
            gender = params[3]
            command = ChildCommand(
                CONST_COMMAND.ADD_CHILD, 
                Person(motherName, CONST_RELATION.FEMALE),
            Person(childName, gender))
        elif cmd == CONST_COMMAND.GET_RELATIONSHIP:
            name =  params[1]
            relation =  params[2]
            command = RelationshipCommand(cmd, Person(name, ""), relation)
    except:
        pass
    return command

#input_file = utils.get_input_file(sys.argv)
input_file = "C:\\Users\\sunny.singh\\Documents\\python\\geektrust\\Family\\test_sample1.txt"
#input_file = "./test_sample1.txt"
if input_file is not None:
    inputList = utils.read_commands(input_file)
    cmdList = []
    if len(inputList) > 0:
        for cmd in inputList:
            command = get_command(cmd)
            if command is not None:
                cmdList.append(get_command(cmd))
    print(inputList)
        
else:
    print(CONST_COMMAND.NONE)