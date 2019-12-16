import CONST_RELATION
from CONST_GENDER import MALE, FEMALE
from CONST_COMMAND import NONE, CHILD_ADDITION_FAILED, CHILD_ADDITION_SUCCEEDED, PERSON_NOT_FOUND, PERSON_NOT_FOUND
SPOUSE = "Spouse"
CHILD = "Child"
MALE_SYMBOL = "[M]"
FEMALE_SYMBOL = "[F]"
LEVEL_SON = 0
LEVEL_DAUGHTER = 0
LEVEL_SIBLINGS = 1
LEVEL_ONE = 1
LEVEL_TWO = 2
EXCLUDE_NAME = True
INCLUDE_SPOUSE = True

class Family:
    def __init__(self, person):
        self.root = person
      
    def find_relationship(self, name, relation):
        if relation == CONST_RELATION.SON:
            return self.get_relationships(name, LEVEL_SON, MALE)
        if relation == CONST_RELATION.DAUGHTER:
            return self.get_relationships(name, LEVEL_DAUGHTER, FEMALE)
        if relation == CONST_RELATION.SIBLINGS:
            return self.get_relationships(name, LEVEL_SIBLINGS, None)
        if relation == CONST_RELATION.SISTER_IN_LAW:
            return self.get_relationships(name, LEVEL_ONE, FEMALE, INCLUDE_SPOUSE)
        if relation == CONST_RELATION.BROTHER_IN_LAW:
            return self.get_relationships(name, LEVEL_ONE, MALE, INCLUDE_SPOUSE)
        if relation == CONST_RELATION.PATERNAL_AUNT:
            return self.get_relationships(name, LEVEL_TWO, FEMALE, False, MALE)
        if relation == CONST_RELATION.PATERNAL_UNCLE:
            return self.get_relationships(name, LEVEL_TWO, MALE, False, MALE)
        if relation == CONST_RELATION.MATERNAL_AUNT:
            return self.get_relationships(name, LEVEL_TWO, FEMALE, False, FEMALE)
        if relation == CONST_RELATION.MATERNAL_UNCLE:
            return self.get_relationships(name, LEVEL_TWO, MALE, False, FEMALE)
        return NONE
    
    def get_parent(self, person, relation):
        if person.parent is not None and person.parent.gender == relation or relation == None:
            return person.parent
        return None

    def get_relationships(self, name, level, gender, includeSpouse = False, maternity = None):
        personList = []
        removeParentName = None
        person = self.find_person(name, self.root)
        if person is not None:
            p = self.get_parent(person, maternity)
            removeParentName = p.name if p is not None else None
            while(level > 0):
                familyParent = None
                if includeSpouse:
                    familyParent = person.get_parent().parent if person.get_parent() is not None else None
                else:
                    familyParent = self.get_parent(person, maternity)
                if familyParent is not None:
                    person = familyParent
                else:
                    person = None
                    break
                maternity = None
                level -= 1
            if person is not None:
                personList = self.filter_gender(person.childrens, gender, includeSpouse)
            if name in personList:
                personList.remove(name)
            if removeParentName is not None and removeParentName in personList:
                personList.remove(removeParentName)
        else:
            personList.append(PERSON_NOT_FOUND)

        return self.list_name(personList)
    
    def filter_gender(self, pList, gender, includeSpouse):
        newList = []
        for p in pList:
            if p.gender == gender or gender is None:
                newList.append(p.name)
            if includeSpouse and p.spouse is not None and (p.spouse.gender == gender or gender is None):
                newList.append(p.spouse.name)
        return newList
        
    def list_name(self, nameList):
        names = NONE
        if len(nameList) > 0:
            return " ".join(nameList)
        return names
    
    def add_spouse(self, name, partner):
        person = self.find_person(name, self.root)
        if person is not None:
            return person.add_spouse(partner)
        return False            
    
    def add_child(self, name, child):
        person = self.find_person(name, self.root)
        if person is not None:
            if person.add_children(child):
                return CHILD_ADDITION_SUCCEEDED
            else:
                return CHILD_ADDITION_FAILED
        return PERSON_NOT_FOUND
    
    def find_person(self, name, person):
        #print(person.name)
        if person.name == name:
            return person
        elif (person.spouse is not None and person.spouse.name == name):
            return person.spouse
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
        pGender = ( MALE_SYMBOL if person.gender == MALE else FEMALE_SYMBOL)
        if person.spouse is not None:
            spouseName = person.spouse.name + ( MALE_SYMBOL if person.spouse.gender == MALE else FEMALE_SYMBOL)
        s = ""
        for i in range(level):
            s += "-"
        print(s +"> "+ person.name + pGender + " : "+ spouseName)
