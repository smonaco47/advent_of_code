import re
from fileImport import *

input = importFile('day9.txt')

sum = 0

def removeEscaped(input):
    condensed = re.sub('!!', '', input)
    condensed = re.sub('!.', '', condensed)
    return condensed

def removeGarbage(input):
    input = removeEscaped(input)
    input = re.sub(',', '', input)
    return re.sub('<.*?>', '', input)

def countGarbage(input):
    input = removeEscaped(input)
    garbageList =  re.findall('<.*?>', input)
    sum = 0
    for garbage in garbageList:
        sum += len(garbage) - 2
    print sum

def parseNesting(input):
    level = 0
    sum = 0
    for char in input:
        if char == '{':
            level += 1
            sum += level
        elif char == '}':
            level -= 1
    return sum


sanitizedInput = removeGarbage(input)
print parseNesting(sanitizedInput)

countGarbage(input)
