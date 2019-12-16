import CONST_COMMAND
from person import Person
from family import Family

class CommandFactory:
    @staticmethod
    def get_command(params):
        cmd = params[0]
        command = None
        try:
            if cmd == CONST_COMMAND.ADD_CHILD:
                parentName = params[1]
                childName = params[2]
                gender = params[3]
                command = ChildCommand(parentName, Person(childName, gender))
            elif cmd == CONST_COMMAND.GET_RELATIONSHIP:
                name =  params[1]
                relativeName =  params[2]
                command = RelationshipCommand(name, relativeName)
            elif cmd == CONST_COMMAND.ADD_SPOUSE:
                spouseName = params[1]
                name = params[2]
                gender = params[3]
                command = SpouseCommand(spouseName, Person(name, gender))
        except:
            pass
        return command
class Command:
    def __init__(self, name):
        self.personName = name
    def execute(self, obj):
        pass

class ChildCommand(Command):
    def __init__(self, personName, child):
        super().__init__(personName)
        self.child = child
    def execute(self, family):
        return family.add_child(self.personName, self.child)

class SpouseCommand(Command):
    def __init__(self, spouseName, partner):
        super().__init__(spouseName)
        self.personName = spouseName
        self.partner =  partner
    
    def execute(self, family):
        return family.add_spouse(self.personName, self.partner)

class RelationshipCommand(Command):
    def __init__(self, personName, relationName):
        super().__init__(personName)
        self.personName = personName
        self.relationName = relationName
    
    def execute(self, family):
        return family.find_relationship(self.personName, self.relationName)
