import CONST_COMMAND
import CONST_RELATION
import CONST_GENDER

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
        if self.parent is not None or self.is_root():
            partner.spouse = self
            self.spouse = partner
            return True
        return False

    def is_valid_mother(self):
        return self.spouse is not None and self.gender == CONST_GENDER.FEMALE

    def get_parent(self):
        if self.parent is not None:
            return self
        elif (self.spouse is not None and self.spouse.is_root()) or self.spouse.parent is not None:
            return self.spouse
        else:
            return None

    def child_exists(self, child):
        if len(child.parent.childrens) > 0:
            for ch in child.parent.childrens:
                if ch.name == child.name:
                    return True
        return False

    def add_children(self, child):
        if self.is_valid_mother():
            child.parent = self.get_parent()
            if child.parent is not None:
                if self.child_exists(child):
                    return False
                child.parent.childrens.append(child)
                return True
        return False
