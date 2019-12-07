import CONST_COMMAND
import CONST_RELATION
import CONST_GENDER
class Family:
    def add_root(self):
        pass
class Person:
    def __init__(self, name, gender):
        self.parent = None
        self.name = name
        self.gender = gender
        self.spouse = None
        self.childrens = []

    def is_root(self):
        if self.name == "King Shan":
            return True
        return False
    def add_spouse(self, partner):
        self.spouse = partner
    def add_children(self, child):
        if self.is_root() or self.parent is not None:
            self.childrens.append(child)
            return True
        return False


