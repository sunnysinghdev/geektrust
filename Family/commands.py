class Command:
    def __init__(self, name):
        self.name = name


class ChildCommand(Command):
    def __init__(self, cmdName, mother, child):
        super().__init__(cmdName)
        self.mother = mother
        self.child = child

class RelationshipCommand(Command):
    def __init__(self, cmd, person, relationship):
        super().__init__(cmd)
        self.person = person
        self.relationship = relationship