import sys
import os
import utils
import CONST_COMMAND
import CONST_RELATION
import CONST_GENDER
from person import Person
from family import Family
from commands import ChildCommand, RelationshipCommand
ROOT_DIR = os.path.dirname(os.path.abspath(__file__))
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
                Person(motherName, CONST_GENDER.FEMALE),
            Person(childName, gender))
        elif cmd == CONST_COMMAND.GET_RELATIONSHIP:
            name =  params[1]
            relation =  params[2]
            command = RelationshipCommand(cmd, Person(name, ""), relation)
    except:
        pass
    return command

#input_file = utils.get_input_file(sys.argv)
input_file = ROOT_DIR + "\\test_sample1.txt"
print(input_file)
#input_file = "./test_sample1.txt"
if input_file is not None:
    inputList = utils.read_commands(input_file," ")
    cmdList = []
    if len(inputList) > 0:
        for cmd in inputList:
            command = get_command(cmd)
            if command is not None:
                cmdList.append(get_command(cmd))
    print(inputList)
        
else:
    print(CONST_COMMAND.NONE)
familyList = [()]
root = Person("King Shan", CONST_GENDER.MALE)
familyRoot = Family(root)
input_file = ROOT_DIR + "\\family_list.txt"
flist = utils.read_commands(input_file, ", ")
for l in flist:
    if(len(l) == 4):
        familyRoot.add_relation(l[0], l[1], Person(l[2], l[3]))
familyRoot.print_tree(root, 0)