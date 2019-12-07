SPOUSE = "Spouse"
CHILD = "Child"
class Family:
    def __init__(self, person):
        self.root = person
    def add_relation(self, relation, name, person):
        if relation == SPOUSE:
            return self.add_spouse(name, person)
        elif relation == CHILD:
            return self.add_child(name, person)
        else:
            return False
    def add_spouse(self, name, partner):
        person = self.find_person(name, self.root)
        if person is not None and (person.parent is not None or person.is_root()):
            person.spouse = partner
            return True
        return False
    def add_child(self, name, child):
        person = self.find_person(name, self.root)
        if person is not None:
            child.parent = person
            person.childrens.append(child)
            return True
        return False
    def find_person(self, name, person):
        print(person.name)
        if person.name == name:
            return person
        for child in person.childrens:
            person = self.find_person(name, child)
            if person is not None:
                return person
        return None
    def print_tree(self, person, level):
        self.print_format(person, level)
        for child in person.childrens:
            self.print_tree(child, level + 1)

    def print_format(self, person, level):
        spouseName = ""
        if person.spouse is not None:
            spouseName = person.spouse.name + person.spouse.gender
        s = ""
        for i in range(level):
            s += "-" 
        print(s +"> "+ person.name + person.gender + " : "+ spouseName)


