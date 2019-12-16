import sys
import os
import utils
import CONST_COMMAND
import CONST_RELATION
import CONST_GENDER
from person import Person
from family import Family
from familyList import familyList
from commands import CommandFactory

#ROOT_DIR = os.path.dirname(os.path.abspath(__file__))

def init_family_tree(familyRoot):
    for params in familyList:
        command = CommandFactory.get_command(params)
        command.execute(familyRoot)

def execute():
    input_file = utils.get_input_file(sys.argv)
    #input_file = ROOT_DIR + "\\test_sample1.txt"
    
    if input_file is not None:
        inputList = utils.read_commands(input_file," ")
        cmdResult = []
        if len(inputList) > 0:
            for params in inputList:
                command = CommandFactory.get_command(params)
                if command is not None:
                    cmdResult.append(command.execute(familyRoot))
            utils.print_list(cmdResult)
        else:
            print(CONST_COMMAND.NONE)
    else:
        print(CONST_COMMAND.NONE)

#-----------------------------------------------
#-----------------------------------------------

root = Person("King Shan", CONST_GENDER.MALE)
familyRoot = Family(root)
init_family_tree(familyRoot)
execute()